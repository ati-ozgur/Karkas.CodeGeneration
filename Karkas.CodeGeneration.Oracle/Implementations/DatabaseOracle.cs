﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.Core.DataUtil;
using System.Data;
using Karkas.CodeGenerationHelper.Generators;
using Karkas.CodeGenerationHelper;
using Karkas.CodeGeneration.Oracle.Generators;

namespace Karkas.CodeGeneration.Oracle.Implementations
{
    public class DatabaseOracle : IDatabase
    {


        public DatabaseOracle(AdoTemplate pTemplate
            ,String pConnectionString
            , string pDatabaseName
            , string pProjectNameSpace
            , string pProjectFolder)
        {
            template = pTemplate;

            connectionString = pConnectionString;

            projectNameSpace = pProjectNameSpace;
            projectFolder = pProjectFolder;
            _DatabaseName = pDatabaseName;

        }
        AdoTemplate template;

        public AdoTemplate Template
        {
            get { return template; }
            set { template = value; }
        }
        string projectNameSpace;
        string connectionString;
        string projectFolder;
        string _DatabaseName;


        public string Name
        {
            get
            {
                return _DatabaseName;
            }
            set
            {
                _DatabaseName = value;
            }
        }

        public string ProjectNameSpace
        {
            get { return projectNameSpace; }
        }

        public string ProjectFolder
        {
            get { return projectFolder; }
        }

        public List<ITable> Tables
        {
            get { throw new NotImplementedException(); }
        }


        public ITable getTable(string pTableName, string pSchemaName)
        {
            return new TableOracle(this,template, pTableName, pSchemaName);
        }

        string databaseName;

        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }


        



        private const string SQL_FOR_DATABASE_NAME = "select sys_context('userenv','db_name') from dual";
        private const string SQL_FOR_SCHEMA_LIST = @"
SELECT '__TUM_SCHEMALAR__' AS TABLE_SCHEMA FROM DUAL
UNION
select username from ALL_users
ORDER BY TABLE_SCHEMA";
        private const string SQL_FOR_TABLE_LIST = @"
SELECT OWNER AS TABLE_SCHEMA, TABLE_NAME,OWNER || '.' || TABLE_NAME  AS FULL_TABLE_NAME  FROM  ALL_TABLES T
WHERE  
(:TABLE_SCHEMA IS NULL) OR ( lower(OWNER) = lower(:TABLE_SCHEMA))

ORDER BY FULL_TABLE_NAME
";

        public string getDatabaseName()
        {
            return (string)template.TekDegerGetir(SQL_FOR_DATABASE_NAME);

        }



        public DataTable getTableListFromSchema( string schemaName)
        {
            ParameterBuilder builder = template.getParameterBuilder();
            builder.parameterEkle(":TABLE_SCHEMA", DbType.String, schemaName);
            DataTable dtTableList = template.DataTableOlustur(SQL_FOR_TABLE_LIST, builder.GetParameterArray());
            return dtTableList;
        }


        public DataTable getSchemaList()
        {
            return template.DataTableOlustur(SQL_FOR_SCHEMA_LIST);
        }




        public void CodeGenerateAllTables(
             string pProjectFolder
            , bool dboSemaTablolariniAtla
            , bool sysTablolariniAtla
            , bool semaIsminiSorgulardaKullan
            , bool semaIsminiDizinlerKullan
            , List<DatabaseAbbreviations> listDatabaseAbbreviations
            )
        {
           
            
            string userName = getUserNameFromConnection(connectionString);

            ParameterBuilder builder = template.getParameterBuilder();
            builder.parameterEkle("TABLE_SCHEMA", DbType.String, userName);

            DataTable dtTables = template.DataTableOlustur(SQL_FOR_TABLE_LIST, builder.GetParameterArray());
            foreach (DataRow row in dtTables.Rows)
            {
                string tableName = row["TABLE_NAME"].ToString();
                string schemaName = row["TABLE_SCHEMA"].ToString();
                CodeGenerateOneTable(  
                    tableName, 
                    schemaName
                    , pProjectFolder
                    , semaIsminiSorgulardaKullan
                    , semaIsminiDizinlerKullan
                    , listDatabaseAbbreviations
                    );
            }

        }

        private string getUserNameFromConnection(string pConnectionString)
        {
            string userName = null;
            string[] list = pConnectionString.Split(';');
            foreach (string item in list)
            {
                if (item.Contains("User ID"))
                {
                    userName = item.Replace("User ID", "");
                    userName = userName.Replace("=", "");
                    userName = userName.Trim();
                    break;
                }
            }
            return userName;
        }

        public void CodeGenerateOneTable(
             string pTableName
            , string pSchemaName
            , string pProjectFolder
            , bool semaIsminiSorgulardaKullan
            , bool semaIsminiDizinlerdeKullan
            , List<DatabaseAbbreviations> listDatabaseAbbreviations
            )
        {
            TypeLibraryGenerator typeGen = new TypeLibraryGenerator(this);
            DalGenerator dalGen = this.DalGenerator;
            BsGenerator bsGen = new BsGenerator(this);
            IOutput output = new OracleOutput();

            ITable table = this.getTable(pTableName, pSchemaName);


            typeGen.Render(output, table,semaIsminiSorgulardaKullan,semaIsminiDizinlerdeKullan, listDatabaseAbbreviations);
            dalGen.Render(output, table, semaIsminiSorgulardaKullan, semaIsminiDizinlerdeKullan,listDatabaseAbbreviations);
            bsGen.Render(output, table, semaIsminiSorgulardaKullan,semaIsminiDizinlerdeKullan, listDatabaseAbbreviations);
        }


        public DalGenerator DalGenerator
        {
            get { return new OracleDalGenerator(this); }
        }


        public string getDefaultSchema()
        {
            string connectionString = template.Connection.ConnectionString;
            return getUserNameFromConnection(connectionString);

        }



    }
}
