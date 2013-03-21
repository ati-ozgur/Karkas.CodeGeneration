﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.Core.DataUtil;
using System.Data;

namespace Karkas.CodeGeneration.Sqlite.Implementations
{
    class ColumnSqlite : IColumn
    {


        public ColumnSqlite(AdoTemplate template, TableSqlite tableSqlite, string columnName, string columnType, bool columnNotNull, string columnDefaultValue, bool columnPK,bool isColumnAutoIncrement)
        {
            // TODO: Complete member initialization
            this.template = template;
            this.table = tableSqlite;
            this.name = columnName;
            this.dataTypeInDatabase = columnType;
            this.isNullable = columnNotNull;
            this.defaultValue = columnDefaultValue;
            this.isInPrimaryKey = columnPK;
            this.isAutoKey = isColumnAutoIncrement;
        }

        private AdoTemplate template;

        private TableSqlite table;
        private string name;

        private bool isAutoKey;

        public bool IsAutoKey
        {
            get 
            {
                // TODO Bunua daha sonra yap
                return isAutoKey;
            }
        }

        public string Name
        {
            get { return name; }
        }



        public bool IsInPrimaryKey
        {
            get
            {
                return isInPrimaryKey;
            }
        }

        private bool? isInForeignKey;
        public bool IsInForeignKey
        {
            get
            {
                if (!isInForeignKey.HasValue)
                {
                    return false;
                    throw new NotImplementedException();

                }
                return isInForeignKey.Value;

            }
        }

        private bool? isNullable = null;
        public bool IsNullable
        {
            get 
            {
                if (!isNullable.HasValue)
                {
                    throw new NotImplementedException();

                }
                return isNullable.Value;
            }
        }

        private string languageType = null;
        private string dataTypeInDatabase = null;







        public string LanguageType
        {
            get 
            {
                if (languageType == null)
                {

                    languageType = sqlTypeToDotnetCSharpType(dataTypeInDatabase);
                }
                return languageType;
            }
        }

        public ITable Table
        {
            get { return table; }
        }

        private bool? isComputed = false;
        public bool IsComputed
        {
            get 
            {
                return isComputed.Value; 
            }
        }

        public string DbTargetType
        {

            get
            {
                string lowerDataTypeInDatabase = dataTypeInDatabase.ToLowerInvariant();
                if (lowerDataTypeInDatabase == "integer")
                {
                    return "DbType.Int32";
                }
                if (lowerDataTypeInDatabase == "real")
                {
                    return "double";
                }

                if (lowerDataTypeInDatabase.Equals("blob"))
                {
                    return "DbType.String";
                }
                return "DbType.String";
            }
        
        }

        public string DataTypeName
        {
            get 
            {
                return sqlTypeToDotnetCommonDbType(dataTypeInDatabase);
            }
        }


        private int? characterMaxLenth = null;
        private string defaultValue;
        private bool isInPrimaryKey;
        public int CharacterMaxLength
        {
            get 
            {
                return 0;
            }
        }

        public bool isStringType
        {
            get 
            {
                if (LanguageType == "string")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool isStringTypeWithoutLength
        {
            get 
            {
                // Sql lite string types all without length
                return true;

            }
        }

        public bool isNumericType
        {
            get 
            {
                return !isStringType;
            }
        }

        // Helper functions

        public string sqlTypeToDotnetCSharpType(string pSqlTypeName)
        {
            //INTEGER - a signed integer
            //REAL - a floating point value
            //TEXT - a text string
            //BLOB - a blob of data
            pSqlTypeName = pSqlTypeName.ToLowerInvariant();

            pSqlTypeName = pSqlTypeName.ToLowerInvariant();
            if (
                    pSqlTypeName.Equals("text")

                )
            {

                return "string";
            }

            if (pSqlTypeName.Equals("integer"))
            {
                return "int";
            }
            if (pSqlTypeName.Equals("real"))
            {
                return "double";
            }
            if ( pSqlTypeName.Equals("blob") )
            {
                return "byte[]";
            }
            return "Unknown";
        }

        private string sqlTypeToDotnetCommonDbType(string dataTypeInDatabase)
        {
            dataTypeInDatabase = dataTypeInDatabase.ToLowerInvariant();
            if (
                    dataTypeInDatabase.Equals("text")
                )
            {

                return "DbType.String";
            }

            if (dataTypeInDatabase.Equals("integer"))
            {
                return "int";
            }

            if (dataTypeInDatabase.Equals("real"))
            {
                return "double";
            }
            if ( dataTypeInDatabase.Equals("blob"))
            {
                return "byte[]";
            }
            return "Unknown";
        }


    }
}