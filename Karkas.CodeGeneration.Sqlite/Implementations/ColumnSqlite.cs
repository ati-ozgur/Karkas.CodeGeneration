using System;
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
        public ColumnSqlite(AdoTemplate pTemplate, TableSqlite pTable, string pName)
        {

            template = pTemplate;
            table = pTable;
            name = pName;

        }

        private AdoTemplate template;

        private TableSqlite table;
        private string name;


        public bool IsAutoKey
        {
            get 
            {
                // TODO Bunua daha sonra yap
                return false;
            }
        }

        public string Name
        {
            get { return name; }
        }

        private bool? isInPrimaryKey;


        public bool IsInPrimaryKey
        {
            get
            {
                if (!isInPrimaryKey.HasValue)
                {
                    throw new NotImplementedException();

                }
                return isInPrimaryKey.Value;

            }
        }

        private bool? isInForeignKey;
        public bool IsInForeignKey
        {
            get
            {
                if (!isInForeignKey.HasValue)
                {
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




        private DataRow columnValuesInDatabase = null;


        private DataRow ColumnValuesInDatabase
        {
            get
            {
                if (columnValuesInDatabase == null)
                {
                    throw new NotImplementedException();

                }
                return columnValuesInDatabase;
            }
        }


        public string LanguageType
        {
            get 
            {
                if (languageType == null)
                {

                    dataTypeInDatabase = ColumnValuesInDatabase["DATA_TYPE"].ToString();
                    languageType = sqlTypeToDotnetCSharpType(dataTypeInDatabase);
                }
                return languageType;
            }
        }

        public ITable Table
        {
            get { return table; }
        }

        private bool? isComputed = null;
        public bool IsComputed
        {
            get 
            {
                if (!isComputed.HasValue)
                {
                    throw new NotImplementedException();
                }
                return isComputed.Value; 
            }
        }

        public string DbTargetType
        {

            get
            {
                string lowerDataTypeInDatabase = dataTypeInDatabase.ToLowerInvariant();
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
        public int CharacterMaxLength
        {
            get 
            { 
                if (!characterMaxLenth.HasValue)
                {
                    if (ColumnValuesInDatabase["DATA_LENGTH"] == DBNull.Value)
                    {
                        characterMaxLenth = 0;
                    }
                    else
                    {
                        characterMaxLenth = Convert.ToInt32(ColumnValuesInDatabase["DATA_LENGTH"]);
                    }

                    
                }

                return characterMaxLenth.Value; 
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
                throw new NotImplementedException();

            }
        }

        public bool isNumericType
        {
            get { throw new NotImplementedException(); }
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
