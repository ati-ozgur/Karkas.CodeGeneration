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
            , bool semaIsminiSorgulardaKullan
            , bool semaIsminiDizinlerdeKullan
            , bool dboSemaTablolariniAtla
            , bool sysTablolariniAtla
            , List<DatabaseAbbreviations> listDatabaseAbbreviations

            )
        {
            template = pTemplate;

            connectionString = pConnectionString;

            projectNameSpace = pProjectNameSpace;
            projectFolder = pProjectFolder;
            logicalDatabaseName = pDatabaseName;

            this.semaIsminiSorgulardaKullan = semaIsminiSorgulardaKullan;
            this.semaIsminiDizinlerdeKullan = semaIsminiDizinlerdeKullan;
            this.listDatabaseAbbreviations = listDatabaseAbbreviations;
            this.dboSemaTablolariniAtla = dboSemaTablolariniAtla;
            this.sysTablolariniAtla = sysTablolariniAtla;

        }

        bool dboSemaTablolariniAtla;

        public bool DboSemaTablolariniAtla
        {
            get { return dboSemaTablolariniAtla; }
            set { dboSemaTablolariniAtla = value; }
        }
        bool sysTablolariniAtla;

        public bool SysTablolariniAtla
        {
            get { return sysTablolariniAtla; }
            set { sysTablolariniAtla = value; }
        }


        bool semaIsminiSorgulardaKullan;

        public bool SemaIsminiSorgulardaKullan
        {
            get { return semaIsminiSorgulardaKullan; }
            set { semaIsminiSorgulardaKullan = value; }
        }
        bool semaIsminiDizinlerdeKullan;

        public bool SemaIsminiDizinlerdeKullan
        {
            get { return semaIsminiDizinlerdeKullan; }
            set { semaIsminiDizinlerdeKullan = value; }
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
        string projectFolder;
        string logicalDatabaseName;


        public string Name
        {
            get
            {
                return logicalDatabaseName;
            }
            set
            {
                logicalDatabaseName = value;
            }
        }

        public string ProjectNameSpace
        {
            get { return projectNameSpace; }
            set {  projectNameSpace = value; }
        }

        public string ProjectFolder
        {
            get 
            { 
                return projectFolder; 
            }
            set 
            { 
                 projectFolder = value; 
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
