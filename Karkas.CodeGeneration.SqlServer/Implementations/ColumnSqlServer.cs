using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Microsoft.SqlServer.Management.Smo;
using System.Collections;
using Karkas.Core.DataUtil;
using System.Data;
using Karkas.CodeGenerationHelper;

namespace Karkas.CodeGeneration.SqlServer.Implementations
{
    public class ColumnSqlServer : IColumn
    {
        Column smoColumn;
        IContainer tableOrView;

        public ColumnSqlServer(Column pSmoColumn, IContainer pTableOrView)
        {
            smoColumn = pSmoColumn;
            tableOrView = pTableOrView;
        }

        public bool IsAutoKey
        {
            get
            {
                if (smoColumn.Identity)
                {
                    return true;
                }
                if (smoColumn.RowGuidCol)
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
                return smoColumn.Name;
            }
        }

        public bool IsInPrimaryKey
        {
            get
            {
                return smoColumn.InPrimaryKey;
            }
        }

        public bool IsInForeignKey
        {
            get
            {
                return smoColumn.IsForeignKey;
            }
        }

        public bool IsNullable
        {
            get
            {
                return smoColumn.Nullable;
            }
        }


        string _LanguageType;
        public string LanguageType
        {
            get
            {
                if (String.IsNullOrEmpty(_LanguageType))
                {
                    string sonuc;
                    if (smoColumn.DataType.SqlDataType.ToString() == "UserDefinedDataType")
                    {
                        string sqlTypeName = getUnderlyingTypeOfUserDefinedType(smoColumn.DataType.Name);
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
                return smoColumn.Computed || smoColumn.RowGuidCol || ( smoColumn.DataType.Name == "timestamp");
                
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
                if (smoColumn.DataType.SqlDataType.ToString() == "UserDefinedDataType")
                {
                    string sqlTypeName = getUnderlyingTypeOfUserDefinedType(smoColumn.DataType.Name);
                    return sqlTypeToDotnetSqlDbType(sqlTypeName);
                }
                if (smoColumn.DataType.SqlDataType.ToString() == "Numeric")
                {
                    return "SqlDbType.Decimal";
                }
                if (smoColumn.DataType.SqlDataType.ToString() == "VarCharMax")
                {
                    return "SqlDbType.VarChar";
                }
                if (smoColumn.DataType.SqlDataType.ToString() == "NVarCharMax")
                {
                    return "SqlDbType.NVarChar";
                }
                if (smoColumn.DataType.SqlDataType.ToString() == "VarBinaryMax")
                {
                    return "SqlDbType.VarBinary";
                }
                
                return "SqlDbType." + smoColumn.DataType.SqlDataType.ToString();
            }
        }

        public string DataTypeName
        {
            get
            {
                string val = smoColumn.DataType.ToString();
                if (val == "")
                {
                    val = smoColumn.DataType.SqlDataType.ToString();

                }
                return val;
            }
        }

        public int CharacterMaxLength
        {
            get
            {

                int charMaxLength = 0;
                if (isStringType)
                {
                    charMaxLength = smoColumn.DataType.MaximumLength;
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
                    string lowerDataType = this.smoColumn.DataType.SqlDataType.ToString().ToLowerInvariant();
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
                string lowerDataType = smoColumn.DataType.ToString().ToLowerInvariant();
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
            get { throw new NotImplementedException(); }
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
