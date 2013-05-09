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
using Karkas.CodeGenerationHelper.BaseClasses;

namespace Karkas.CodeGeneration.Oracle.Implementations
{
    public class DatabaseOracle : BaseDatabase
    {

        public DatabaseOracle(AdoTemplate template)
        {
            this.Template = template;
        }


        public DatabaseOracle(AdoTemplate template
            ,string connectionString
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
            this.Template = template;

            this.ConnectionString = connectionString;

            this.ProjectNameSpace = pProjectNameSpace;
            this.CodeGenerationDirectory = pProjectFolder;
            this.LogicalDatabaseName = pDatabaseName;
            this.ConnectionDbProviderName = dbProviderName;

            this.UseSchemaNameInSqlQueries = semaIsminiSorgulardaKullan;
            this.UseSchemaNameInFolders = semaIsminiDizinlerdeKullan;
            this.ListDatabaseAbbreviations = listDatabaseAbbreviations;
            this.IgnoreSystemTables = sysTablolariniAtla;

        }


        public string LogicalDatabaseName { get; set; }


        public override List<ITable> Tables
        {
            get { throw new NotImplementedException(); }
        }


        public override ITable getTable(string pTableName, string pSchemaName)
        {
            return new TableOracle(this,Template, pTableName, pSchemaName);
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
                    databaseNamePhysical = (string)Template.TekDegerGetir(SQL_FOR_DATABASE_NAME);
                }
                return databaseNamePhysical;
            }
            set
            {
                databaseNamePhysical = value;
            }
        }



        public override DataTable getTableListFromSchema(string schemaName)
        {
            ParameterBuilder builder = Template.getParameterBuilder();
            builder.parameterEkle(":TABLE_SCHEMA", DbType.String, schemaName);
            DataTable dtTableList = Template.DataTableOlustur(SQL_FOR_TABLE_LIST, builder.GetParameterArray());
            return dtTableList;
        }


        public override DataTable getSchemaList()
        {
            return Template.DataTableOlustur(SQL_FOR_SCHEMA_LIST);
        }




        public override void CodeGenerateAllTables()
        {
           
            
            string userName = getUserNameFromConnection(ConnectionString);

            ParameterBuilder builder = Template.getParameterBuilder();
            builder.parameterEkle("TABLE_SCHEMA", DbType.String, userName);

            DataTable dtTables = Template.DataTableOlustur(SQL_FOR_TABLE_LIST, builder.GetParameterArray());
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

        private  string getUserNameFromConnection(string pConnectionString)
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

        public override void CodeGenerateOneTable(
             string pTableName
            , string pSchemaName
            )
        {
            TypeLibraryGenerator typeGen = new TypeLibraryGenerator(this);
            DalGenerator dalGen = this.DalGenerator;
            BsGenerator bsGen = new BsGenerator(this);
            IOutput output = new OracleOutput();

            ITable table = this.getTable(pTableName, pSchemaName);


            typeGen.Render(output, table,UseSchemaNameInSqlQueries,UseSchemaNameInFolders, ListDatabaseAbbreviations);
            dalGen.Render(output, table, UseSchemaNameInSqlQueries, UseSchemaNameInFolders,ListDatabaseAbbreviations);
            bsGen.Render(output, table, UseSchemaNameInSqlQueries, UseSchemaNameInFolders, ListDatabaseAbbreviations);
        }


        public override DalGenerator DalGenerator
        {
            get { return new OracleDalGenerator(this); }
        }

        string defaultSchema;
        public override string getDefaultSchema()
        {
            if (string.IsNullOrEmpty(defaultSchema))
            {
                defaultSchema = getUserNameFromConnection(ConnectionString);
            }
            return defaultSchema;

        }



    }
}
