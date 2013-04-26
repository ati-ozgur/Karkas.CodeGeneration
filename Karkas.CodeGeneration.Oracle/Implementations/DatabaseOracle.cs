using System;
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
            , string pProjectFolder
            , string dbProviderName
            , bool semaIsminiSorgulardaKullan
            , bool semaIsminiDizinlerdeKullan
            , bool sysTablolariniAtla
            , List<DatabaseAbbreviations> listDatabaseAbbreviations

            )
        {
            this.template = pTemplate;

            this.connectionString = pConnectionString;

            this.projectNameSpace = pProjectNameSpace;
            this.codeGenerationDirectory = pProjectFolder;
            this.logicalDatabaseName = pDatabaseName;
            this.dbProviderName = dbProviderName;

            this.useSchemaNameInSqlQueries = semaIsminiSorgulardaKullan;
            this.useSchemaNameInFolders = semaIsminiDizinlerdeKullan;
            this.listDatabaseAbbreviations = listDatabaseAbbreviations;
            this.ignoreSystemTables = sysTablolariniAtla;

        }


        bool ignoreSystemTables;

        public bool IgnoreSystemTables
        {
            get { return ignoreSystemTables; }
            set { ignoreSystemTables = value; }
        }

        string dbProviderName;

        public string DbProviderName
        {
            get { return dbProviderName; }
            set { dbProviderName = value; }
        }


        bool useSchemaNameInSqlQueries;

        public bool UseSchemaNameInSqlQueries
        {
            get { return useSchemaNameInSqlQueries; }
            set { useSchemaNameInSqlQueries = value; }
        }
        bool useSchemaNameInFolders;

        public bool UseSchemaNameInFolders
        {
            get { return useSchemaNameInFolders; }
            set { useSchemaNameInFolders = value; }
        }


        string ignoredSchemaList;

        public string IgnoredSchemaList
        {
            get { return ignoredSchemaList; }
            set { ignoredSchemaList = value; }
        }
        string databaseAbbreviations;

        public string DatabaseAbbreviations
        {
            get { return databaseAbbreviations; }
            set { databaseAbbreviations = value; }
        }



        List<DatabaseAbbreviations> listDatabaseAbbreviations;

        public List<DatabaseAbbreviations> ListDatabaseAbbreviations
        {
            get { return listDatabaseAbbreviations; }
            set { listDatabaseAbbreviations = value; }
        }


        AdoTemplate template;

        public AdoTemplate Template
        {
            get { return template; }
            set { template = value; }
        }
        string projectNameSpace;
        string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        string codeGenerationDirectory;
        string logicalDatabaseName;

        string connectionName;

        public string ConnectionName
        {
            get
            {
                return connectionName;
            }
            set
            {
                connectionName = value;
            }
        }
        string connectionDatabaseType;

        public string ConnectionDatabaseType
        {
            get
            {
                return connectionDatabaseType;
            }
            set
            {
                connectionDatabaseType = value;
            }
        }

        public string ProjectNameSpace
        {
            get { return projectNameSpace; }
            set {  projectNameSpace = value; }
        }

        public string CodeGenerationDirectory
        {
            get 
            { 
                return codeGenerationDirectory; 
            }
            set 
            { 
                 codeGenerationDirectory = value; 
            }
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

        public string DatabaseNameLogical
        {
            get { return databaseName; }
            set { databaseName = value; }
        }


        bool viewCodeGenerateEtsinMi;

        public bool ViewCodeGenerate
        {
            get { return viewCodeGenerateEtsinMi; }
            set { viewCodeGenerateEtsinMi = value; }
        }
        bool storedProcedureCodeGenerateEtsinMi;

        public bool StoredProcedureCodeGenerate
        {
            get { return storedProcedureCodeGenerateEtsinMi; }
            set { storedProcedureCodeGenerateEtsinMi = value; }
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

        private string databaseNamePhysical;

        public string DatabaseNamePhysical
        {
            get
            {
                if (String.IsNullOrEmpty(databaseNamePhysical))
                {
                    databaseNamePhysical = (string)template.TekDegerGetir(SQL_FOR_DATABASE_NAME);
                }
                return databaseNamePhysical;
            }
            set
            {
                databaseNamePhysical = value;
            }
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




        public void CodeGenerateAllTables()
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
                    );
            }

        }

        private string getUserNameFromConnection(string pConnectionString)
        {
            string userName = null;
            string[] list = pConnectionString.ToUpperInvariant().Split(';');
            foreach (string item in list)
            {

                if (item.Contains("USER ID"))
                {
                    userName = item.Replace("USER ID", "");
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
            )
        {
            TypeLibraryGenerator typeGen = new TypeLibraryGenerator(this);
            DalGenerator dalGen = this.DalGenerator;
            BsGenerator bsGen = new BsGenerator(this);
            IOutput output = new OracleOutput();

            ITable table = this.getTable(pTableName, pSchemaName);


            typeGen.Render(output, table,useSchemaNameInSqlQueries,useSchemaNameInFolders, listDatabaseAbbreviations);
            dalGen.Render(output, table, useSchemaNameInSqlQueries, useSchemaNameInFolders,listDatabaseAbbreviations);
            bsGen.Render(output, table, useSchemaNameInSqlQueries,useSchemaNameInFolders, listDatabaseAbbreviations);
        }


        public DalGenerator DalGenerator
        {
            get { return new OracleDalGenerator(this); }
        }

        string defaultSchema;
        public string getDefaultSchema()
        {
            if (string.IsNullOrEmpty(defaultSchema))
            {
                defaultSchema = getUserNameFromConnection(ConnectionString);
            }
            return defaultSchema;

        }



    }
}
