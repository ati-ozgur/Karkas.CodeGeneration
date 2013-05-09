using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.CodeGenerationHelper;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using Karkas.CodeGenerationHelper.Generators;
using Karkas.Core.DataUtil;
using System.Data;
using Karkas.CodeGeneration.SqlServer.Generators;
using Karkas.CodeGenerationHelper.BaseClasses;


namespace Karkas.CodeGeneration.SqlServer.Implementations
{
    public class DatabaseSqlServer : BaseDatabase
    {
        internal Server smoServer;
        internal Database smoDatabase;

        public DatabaseSqlServer(AdoTemplate template)
        {
            this.Template = template;
        }

        public DatabaseSqlServer(
            AdoTemplate template
            , String pConnectionString
            ,string pDatabaseName
            ,string pProjectNameSpace
            ,string codeGenerationDirectory
            , string dbProviderName
            , bool semaIsminiSorgulardaKullan
            ,bool semaIsminiDizinlerdeKullan
            , bool sysTablolariniAtla
            , List<DatabaseAbbreviations> listDatabaseAbbreviations
            
            )
        {
            this.Template = template;
            this.ConnectionString = ConnectionHelper.RemoveProviderFromConnectionString(pConnectionString);
            this.smoServer = new Server(new ServerConnection(new SqlConnection(ConnectionString)));
            this.smoDatabase = smoServer.Databases[pDatabaseName];
            this.ProjectNameSpace = pProjectNameSpace;
            this.CodeGenerationDirectory = codeGenerationDirectory;


            this.ConnectionDbProviderName = dbProviderName;
            this.UseSchemaNameInSqlQueries = semaIsminiSorgulardaKullan;
            this.UseSchemaNameInFolders = semaIsminiDizinlerdeKullan;
            this.ListDatabaseAbbreviations = listDatabaseAbbreviations;
            this.IgnoreSystemTables = sysTablolariniAtla;

        }



        string databaseName;

        public string DatabaseNameLogical
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string ConnectionName
        {
            get
            {
                return smoDatabase.Name;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        List<ITable> _tableList;

        public override List<ITable> Tables
        {
           
            get 
            {
                if (_tableList == null)
                {
                    _tableList = new List<ITable>();
                    foreach (Table smoTable in smoDatabase.Tables)
                    {
                        ITable t = new TableSqlServer(this, smoTable.Name, smoTable.Schema);
                        _tableList.Add(t);
                    }
                }
                return _tableList;
            
            }
        }

        public override string ToString()
        {
            return ConnectionName;
        }


        public override ITable getTable(string pTableName, string pSchemaName)
        {
             ITable t = new TableSqlServer(this, pTableName, pSchemaName);
             return t;
        }







        private const string SQL__FOR_SCHEMA_LIST = @"
SELECT '__TUM_SCHEMALAR__' AS TABLE_SCHEMA FROM INFORMATION_SCHEMA.TABLES
UNION
SELECT DISTINCT TABLE_SCHEMA FROM INFORMATION_SCHEMA.TABLES
";



        private const string SQL_FOR_TABLE_LIST = @"
SELECT TABLE_SCHEMA,TABLE_NAME, TABLE_SCHEMA + '.' + TABLE_NAME AS FULL_TABLE_NAME FROM INFORMATION_SCHEMA.TABLES
WHERE
( (@TABLE_SCHEMA IS NULL) OR (@TABLE_SCHEMA = '__TUM_SCHEMALAR__') OR ( TABLE_SCHEMA = @TABLE_SCHEMA))
AND
TABLE_TYPE = 'BASE TABLE'
ORDER BY FULL_TABLE_NAME
";

        private const string SQL_FOR_DATABASE_NAME = @"
SELECT DISTINCT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES
";

        private string databaseNamePhysical;

        public override string DatabaseNamePhysical
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
            ParameterBuilder builder = new ParameterBuilder();
            builder.parameterEkle("@TABLE_SCHEMA", DbType.String, schemaName);
            DataTable dtTableList = Template.DataTableOlustur(SQL_FOR_TABLE_LIST, builder.GetParameterArray());
            return dtTableList;
        }

        private const string SQL_FOR_VIEW_LIST = @"
SELECT TABLE_SCHEMA,TABLE_NAME, TABLE_SCHEMA + '.' + TABLE_NAME AS FULL_TABLE_NAME
 FROM INFORMATION_SCHEMA.VIEWS
WHERE
( (@TABLE_SCHEMA IS NULL) OR (@TABLE_SCHEMA = '__TUM_SCHEMALAR__') OR ( TABLE_SCHEMA = @TABLE_SCHEMA))
ORDER BY FULL_TABLE_NAME
";


        public override DataTable getViewListFromSchema(string schemaName)
        {
            ParameterBuilder builder = new ParameterBuilder();
            builder.parameterEkle("@TABLE_SCHEMA", DbType.String, schemaName);
            DataTable dtTableList = Template.DataTableOlustur(SQL_FOR_VIEW_LIST, builder.GetParameterArray());
            return dtTableList;
        }

        public override DataTable getSchemaList()
        {
            return Template.DataTableOlustur(SQL__FOR_SCHEMA_LIST);
        }




        public override void CodeGenerateAllTables()
        {
            TypeLibraryGenerator typeGen = new TypeLibraryGenerator(this);
            DalGenerator dalGen = this.DalGenerator;
            BsGenerator bsGen = new BsGenerator(this);
            IOutput output = new SqlServerOutput();

            List<ITable> tableListesi = this.Tables;

            foreach (ITable table in tableListesi)
            {
                if (IgnoreSystemTables && (table.Name.StartsWith("sys") || table.Name == "dtproperties"))
                {
                    continue;
                }
                typeGen.Render(output, table, UseSchemaNameInSqlQueries, UseSchemaNameInFolders,ListDatabaseAbbreviations);
                dalGen.Render(output, table, UseSchemaNameInSqlQueries, UseSchemaNameInFolders, ListDatabaseAbbreviations);
                bsGen.Render(output, table, UseSchemaNameInSqlQueries, UseSchemaNameInFolders, ListDatabaseAbbreviations);
            }
        }

        public override void CodeGenerateOneTable(
             string pTableName
            , string pSchemaName
            )
        {
            TypeLibraryGenerator typeGen = new TypeLibraryGenerator(this);
            DalGenerator dalGen = this.DalGenerator;
            BsGenerator bsGen = new BsGenerator(this);
            IOutput output = new SqlServerOutput();

            ITable table = this.getTable(pTableName, pSchemaName);

            typeGen.Render(output, table, UseSchemaNameInSqlQueries, UseSchemaNameInFolders, ListDatabaseAbbreviations);
            dalGen.Render(output, table, UseSchemaNameInSqlQueries, UseSchemaNameInFolders, ListDatabaseAbbreviations);
            bsGen.Render(output, table, UseSchemaNameInSqlQueries, UseSchemaNameInFolders, ListDatabaseAbbreviations);
        }






        public override DalGenerator DalGenerator
        {
            get { return new SqlServerDalGenerator(this); }
        }


        public override string getDefaultSchema()
        {
            return "dbo";
        }

    }
}
