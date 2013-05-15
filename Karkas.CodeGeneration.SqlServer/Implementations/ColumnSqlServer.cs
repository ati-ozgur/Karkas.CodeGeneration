﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using System.Collections;
using Karkas.Core.DataUtil;
using System.Data;
using Karkas.CodeGenerationHelper;

namespace Karkas.CodeGeneration.SqlServer.Implementations
{
    public class ColumnSqlServer : IColumn
    {
        IContainer tableOrView;
        string columnName;
        DataRow columnValuesFromInformationSchema;
        DataRow columnValuesFromSysViews;
        AdoTemplate template;

        public ColumnSqlServer(IContainer pTableOrView, AdoTemplate template, string columnName,DataRow columnValues)
        {
            tableOrView = pTableOrView;
            this.template = template;
            this.columnName = columnName;
            this.columnValuesFromInformationSchema = columnValues;

            ParameterBuilder defaultParameterBuilder = getBuilderWithDefaultValues();

            DataTable dt = template.DataTableOlustur(SQL_COLUMN_VALUES_FROM_SYS, defaultParameterBuilder.GetParameterArray());
            columnValuesFromSysViews = dt.Rows[0];


            
        }

        private ParameterBuilder getBuilderWithDefaultValues()
        {
            ParameterBuilder builder = template.getParameterBuilder();
            builder.parameterEkle("@TABLE_NAME", DbType.AnsiString, tableOrView.Name);
            builder.parameterEkle("@TABLE_SCHEMA", DbType.AnsiString, tableOrView.Schema);
            builder.parameterEkle("@COLUMN_NAME", DbType.AnsiString, columnName);
            return builder;
        }

        private const string SQL_COLUMN_VALUES_FROM_SYS = @"SELECT object_id
      ,name
      ,column_id
      ,system_type_id
      ,user_type_id
      ,max_length
      ,precision
      ,scale
      ,collation_name
      ,is_nullable
      ,is_ansi_padded
      ,is_rowguidcol
      ,is_identity
      ,is_computed
      ,is_filestream
      ,is_replicated
      ,is_non_sql_subscribed
      ,is_merge_published
      ,is_dts_replicated
      ,is_xml_document
      ,xml_collection_id
      ,default_object_id
      ,rule_object_id
      ,is_sparse
      ,is_column_set
  FROM sys.columns sc
  WHERE sc.object_id  = 
  (
  SELECT so.object_id FROM sys.objects so
WHERE name = @TABLE_NAME
AND schema_id = 
    (SELECT schema_id 
    FROM sys.schemas
    WHERE name = @TABLE_SCHEMA)
   ) 
   and
   name =  @COLUMN_NAME
";


        public bool IsAutoKey
        {
            get
            {
                if (columnValuesFromSysViews["is_identity"].ToString() == "1")
                {
                    return true;
                }
                if (columnValuesFromSysViews["is_rowguidcol"].ToString() == "1")
                {
                    return true;
                }
                return false;
            }
        }

        public string Name
        {
            get
            {
                return columnName;
            }
        }

        private const string SQL_PRIMARY_KEY_INFO = @"SELECT COUNT(*)
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS C
JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS K
ON C.TABLE_NAME = K.TABLE_NAME
AND C.CONSTRAINT_CATALOG = K.CONSTRAINT_CATALOG
AND C.CONSTRAINT_SCHEMA = K.CONSTRAINT_SCHEMA
AND C.CONSTRAINT_NAME = K.CONSTRAINT_NAME
WHERE C.CONSTRAINT_TYPE = 'PRIMARY KEY'
AND K.COLUMN_NAME = @COLUMN_NAME
AND K.TABLE_NAME = @TABLE_NAME
AND K.TABLE_SCHEMA = @TABLE_SCHEMA";
        private const string SQL_FOREIGN_KEY_INFO = @"SELECT COUNT(*)
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS C
JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS K
ON C.TABLE_NAME = K.TABLE_NAME
AND C.CONSTRAINT_CATALOG = K.CONSTRAINT_CATALOG
AND C.CONSTRAINT_SCHEMA = K.CONSTRAINT_SCHEMA
AND C.CONSTRAINT_NAME = K.CONSTRAINT_NAME
WHERE C.CONSTRAINT_TYPE = 'FOREIGN KEY'
AND K.COLUMN_NAME = @COLUMN_NAME
AND K.TABLE_NAME = @TABLE_NAME
AND K.TABLE_SCHEMA = @TABLE_SCHEMA";

        bool? isInPrimaryKey;

        public bool IsInPrimaryKey
        {
            get
            {
                if (isInPrimaryKey.HasValue)
                {
                    return isInPrimaryKey.Value;
                }
                else
                {
                    int sonuc = (int)template.TekDegerGetir(SQL_PRIMARY_KEY_INFO, getBuilderWithDefaultValues().GetParameterArray());
                    return sonuc > 0;
                }
            }
        }
        bool? isInForeignKey;

        public bool IsInForeignKey
        {

            get
            {
                if (isInForeignKey.HasValue)
                {
                    return isInForeignKey.Value;
                }
                else
                {
                    int sonuc = (int)template.TekDegerGetir(SQL_FOREIGN_KEY_INFO, getBuilderWithDefaultValues().GetParameterArray());
                    if (sonuc > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool IsNullable
        {
            get
            {
                string isNullableValue = columnValuesFromInformationSchema["IS_NULLABLE"].ToString();
                if (isNullableValue == "NO")
                {
                    return false;
                }
                if (isNullableValue == "YES")
                {
                    return true;
                }

                throw new NotSupportedException("Nullable value YES veya NO olmalı. Buraya Gelmemesi gerekir.");
            }
        }


        string _LanguageType;
        string _SqlDataType;
        public string LanguageType
        {
            get
            {
                if (String.IsNullOrEmpty(_LanguageType))
                {

                    string sonuc;
                    if (SqlDataTypeName == "UserDefinedDataType")
                    {
                        throw new NotImplementedException("UserDefinedDataType cevrimi");
                        string sqlTypeName = getUnderlyingTypeOfUserDefinedType(SqlDataTypeName);
                        sonuc = sqlTypeToDotnetCSharpType(sqlTypeName);
                    }
                    else
                    {
                        sonuc = sqlTypeToDotnetCSharpType(DataTypeName);

                    }
                    if (sonuc.Equals("Unknown"))
                    {
                        Console.WriteLine("TableName : {0}, Name : {1} , DataType : {2} ", TableFullName, Name, DataTypeName);
                    }
                    _LanguageType = sonuc;
                }
                return _LanguageType;
            }
        }
        public string TableFullName
        {
            get
            {
                return String.Format("{0}.{1}", Table.Schema, Table.Name);
            }
        }

        public string TableName
        {
            get
            {
                return Table.Name;
            }
        }



        public bool IsComputed
        {
            get
            {
                bool isComputed = Convert.ToInt32(columnValuesFromSysViews["is_computed"]) > 0 ;
                bool is_rowguidcol = Convert.ToInt32(columnValuesFromSysViews["is_rowguidcol"]) > 0;

                return isComputed || is_rowguidcol || (SqlDataTypeName == "timestamp");
                
            }
        }

        static Dictionary<string, string> userDefinedTypes = new Dictionary<string, string>();

        private string getUnderlyingTypeOfUserDefinedType(string pUserDefinedTypeName)
        {
            string underlyingType;

            string sql = @"SELECT name FROM sys.types
 WHERE system_type_id =
( SELECT system_type_id from  sys.types
 where name = @UserDefinedTypeName)
 and is_user_defined = 0
";

            ParameterBuilder builder = new ParameterBuilder();
            builder.parameterEkle("@UserDefinedTypeName", DbType.String, pUserDefinedTypeName);
            AdoTemplate template = new AdoTemplate();
            underlyingType = (string)template.TekDegerGetir(sql, builder.GetParameterArray());

            return underlyingType;


        }

        public string sqlTypeToDotnetSqlDbType(string pSqlTypeName)
        {
            if (pSqlTypeName == "char")
            {
                return "SqlDbType.Char";
            }
            return "Unknown";
        }
        public string sqlTypeToDotnetCSharpType(string pSqlTypeName)
        {
            if (
                    pSqlTypeName.Equals("varchar") ||
                    pSqlTypeName.Equals("nvarchar") ||
                    pSqlTypeName.Equals("char") ||
                    pSqlTypeName.Equals("nchar") ||
                    pSqlTypeName.Equals("ntext") ||
                    pSqlTypeName.Equals("Xml") ||
                    pSqlTypeName.Equals("text")

                )
            {

                return "string";
            }
            if (pSqlTypeName.Equals("uniqueidentifier"))
            {
                return "Guid";
            }
            if (pSqlTypeName.Equals("int"))
            {
                return "int";
            }
            if (pSqlTypeName.Equals("tinyint"))
            {
                return "byte";
            }
            if (pSqlTypeName.Equals("smallint"))
            {
                return "short";
            }
            if (pSqlTypeName.Equals("bigint"))
            {
                return "long";
            }
            if (
                pSqlTypeName.Equals("datetime") ||
                pSqlTypeName.Equals("smalldatetime")
                )
            {
                return "DateTime";
            }
            if (pSqlTypeName.Equals("bit"))
            {
                return "bool";
            }
            if (pSqlTypeName.Equals("bit"))
            {
                return "bool";
            }



            if (
                pSqlTypeName.Equals("numeric") ||
                pSqlTypeName.Equals("decimal") ||
                pSqlTypeName.Equals("money") ||
                pSqlTypeName.Equals("smallmoney")
                )
            {
                return "decimal";
            }
            if (pSqlTypeName.Equals("float"))
            {
                return "double";
            }
            if (pSqlTypeName.Equals("real"))
            {
                return "float";
            }
            if (
                pSqlTypeName.Equals("image") ||
                pSqlTypeName.Equals("binary") ||
                pSqlTypeName.Equals("varbinary") ||
                pSqlTypeName.Equals("timestamp")
                )
            {
                return "byte[]";
            }
            if (pSqlTypeName.Equals("sql_variant"))
            {
                return "object";
            }
            return "Unknown";
        }

        public string DbTargetType
        {
            get
            {
                if (SqlDataTypeName == "UserDefinedDataType")
                {
                    string sqlTypeName = getUnderlyingTypeOfUserDefinedType(SqlDataTypeName);
                    return sqlTypeToDotnetSqlDbType(sqlTypeName);
                }
                if (SqlDataTypeName == "Numeric")
                {
                    return "SqlDbType.Decimal";
                }
                if (SqlDataTypeName == "VarCharMax")
                {
                    return "SqlDbType.VarChar";
                }
                if (SqlDataTypeName == "NVarCharMax")
                {
                    return "SqlDbType.NVarChar";
                }
                if (SqlDataTypeName == "VarBinaryMax")
                {
                    return "SqlDbType.VarBinary";
                }
                
                return "SqlDbType." + SqlDataTypeName;
            }
        }

        private string sqlDataTypeName;

        public string SqlDataTypeName
        {
            get { return DataTypeName; }
        }
        public string DataTypeName
        {
            get
            {
                if (sqlDataTypeName == null)
                {
                    sqlDataTypeName = columnValuesFromInformationSchema["DATA_TYPE"].ToString();
                }
                return sqlDataTypeName;
        }
        }

        public int CharacterMaxLength
        {
            get
            {

                int charMaxLength = 0;
                if (isStringType)
                {
                    charMaxLength = Convert.ToInt32(columnValuesFromInformationSchema["CHARACTER_MAXIMUM_LENGTH"]);
                }
                return charMaxLength;
            }
        }

        public bool isStringTypeWithoutLength
        {
            get
            {
                if (isStringType)
                {
                    string lowerDataType = this.SqlDataTypeName.ToLowerInvariant();
                    if (
                        lowerDataType.Contains("text")
                        || lowerDataType.Contains("max")
                        )
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool isStringType
        {
            get
            {
                string lowerDataType = SqlDataTypeName.ToLowerInvariant();
                if (
                    lowerDataType.Contains("char")
                    ||
                    lowerDataType.Contains("text")

                    )
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }


        public bool isNumericType
        {
            get { 
                if (
                    SqlDataTypeName == "tinyint" || 
                    SqlDataTypeName == "short" || 
                    SqlDataTypeName == "byte" || 
                    SqlDataTypeName == "int" || 
                    SqlDataTypeName == "numeric" || 
                    SqlDataTypeName == "decimal" || 
                    SqlDataTypeName == "float" || 
                    SqlDataTypeName == "real" || 
                    SqlDataTypeName == "money" 
                    )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            
            }
        }

        public ITable Table
        {
            get
            {
                if (tableOrView is ITable)
                {
                    return (ITable)tableOrView;
                }
                throw new NotSupportedException("Bu column bir view'a ait.");
            }
        }

        public IView View
        {
            get
            {
                if (tableOrView is IView)
                {
                    return (IView)tableOrView;
                }
                throw new NotSupportedException("Bu column bir tabloya ait.");
            }
        }

        public string ContainerName
        {
            get { return tableOrView.Name; }
        }

        public string ContainerSchemaName
        {
            get { return tableOrView.Schema; }
        }



    }
}
