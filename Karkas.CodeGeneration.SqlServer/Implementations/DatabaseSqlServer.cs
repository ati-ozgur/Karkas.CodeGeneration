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
            : base(template)
        {
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
            : base(template)
        {
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
            ParameterBuilder builder = Template.getParameterBuilder();
            builder.parameterEkle("@TABLE_SCHEMA", DbType.String, schemaName);
            DataTable dtTableList = Template.DataTableOlustur(SQL_FOR_TABLE_LIST, builder.GetParameterArray());
            return dtTableList;
        }

        private const string SQL_FOR_VIEW_LIST = @"
SELECT TABLE_SCHEMA AS VIEW_SCHEMA,TABLE_NAME AS VIEW_NAME, TABLE_SCHEMA + '.' + TABLE_NAME AS FULL_VIEW_NAME
 FROM INFORMATION_SCHEMA.VIEWS
WHERE
( (@TABLE_SCHEMA IS NULL) OR (@TABLE_SCHEMA = '__TUM_SCHEMALAR__') OR ( TABLE_SCHEMA = @TABLE_SCHEMA))
ORDER BY FULL_VIEW_NAME
";


        public override DataTable getViewListFromSchema(string schemaName)
        {
            ParameterBuilder builder = Template.getParameterBuilder();
            builder.parameterEkle("@TABLE_SCHEMA", DbType.String, schemaName);
            DataTable dtTableList = Template.DataTableOlustur(SQL_FOR_VIEW_LIST, builder.GetParameterArray());
            return dtTableList;
        }



        private const string SQL_FOR_STORED_PROCEDURE_LIST = @"
SELECT
      ROUTINE_SCHEMA AS SP_SCHEMA_NAME
      ,ROUTINE_NAME  AS STORED_PROCEDURE_NAME
  FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_TYPE = 'PROCEDURE'
AND
( (@SP_SCHEMA_NAME IS NULL) OR (@SP_SCHEMA_NAME = '__TUM_SCHEMALAR__') OR ( ROUTINE_SCHEMA = @SP_SCHEMA_NAME))
ORDER BY STORED_PROCEDURE_NAME
";


        public override DataTable getStoredProcedureListFromSchema(string schemaName)
        {
            ParameterBuilder builder = Template.getParameterBuilder();
            builder.parameterEkle("@SP_SCHEMA_NAME", DbType.String, schemaName);
            DataTable dtTableList = Template.DataTableOlustur(SQL_FOR_STORED_PROCEDURE_LIST, builder.GetParameterArray());
            return dtTableList;
        }

        private const string SQL_FOR_SEQUENCES_LIST = @"
SELECT
SCHEMA_NAME(seq.schema_id) AS SEQ_SCHEMA_NAME
,seq.name AS SEQUENCE_NAME
FROM
sys.sequences AS seq
WHERE
1 = 1
AND
( (@SEQ_SCHEMA_NAME IS NULL) OR (@SEQ_SCHEMA_NAME = '__TUM_SCHEMALAR__') OR ( SEQ_SCHEMA_NAME = @SEQ_SCHEMA_NAME))
ORDER BY SEQUENCE_NAME
";
        // TODO Test 2012
        public override DataTable getSequenceListFromSchema(string schemaName)
        {
            DataTable dt = new DataTable();
            try
            {
                ParameterBuilder builder = Template.getParameterBuilder();
                builder.parameterEkle("@SEQ_SCHEMA_NAME", DbType.String, schemaName);
                dt = Template.DataTableOlustur(SQL_FOR_SEQUENCES_LIST, builder.GetParameterArray());
            }
            catch
            {
                // sql server 2000-2008 does not support sequences but 2012 do.
                // sql server 2000-2008 arasında sequences yok ama 2012'de var.
                // exception yut.
            }
            return dt;
        }


        public override DataTable getSchemaList()
        {
            return Template.DataTableOlustur(SQL__FOR_SCHEMA_LIST);
        }


        public override void CodeGenerateOneSequence(string sequenceName, string schemaName)
        {
            // TODO
            throw new NotImplementedException();
        }


        IOutput output = new SqlServerOutput();
        public override IOutput Output
        {
            get
            {
                return output;
            }
        }

        public override IView GetView(string pViewName, string pSchemaName)
        {
            return new ViewSqlServer(this, Template, pViewName, pSchemaName);
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
