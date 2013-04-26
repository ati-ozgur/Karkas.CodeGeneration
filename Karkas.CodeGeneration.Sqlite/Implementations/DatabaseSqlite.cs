using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.Core.DataUtil;
using System.Data;
using Karkas.CodeGenerationHelper.Generators;
using Karkas.CodeGeneration.Sqlite.Generators;

namespace Karkas.CodeGeneration.Sqlite.Implementations
{
    public class DatabaseSqlite : IDatabase
    {
        


        public DatabaseSqlite(AdoTemplate pTemplate
            , String pConnectionString
            , string pDatabaseName
            , string pProjectNameSpace
            , string pProjectFolder
            
            )
        {
            template = pTemplate;

            connectionString = pConnectionString;

            _projectNameSpace = pProjectNameSpace;
            _projectFolder = pProjectFolder;
            _DatabaseName = pDatabaseName;

        }
        AdoTemplate template;
        string _projectNameSpace;
        string connectionString;
        string _projectFolder;
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

        public string projectNameSpace
        {
            get { return _projectNameSpace; }
        }

        public string projectFolder
        {
            get { return _projectFolder; }
        }

        private const string TABLE_LIST_SQL = @"SELECT '' AS TABLE_SCHEMA, 
                                                name AS TABLE_NAME,
                                                name AS FULL_TABLE_NAME 
                                                FROM sqlite_master
                                                WHERE type='table'
                                                ORDER BY name;";


        List<ITable> _tableList = null;

        public List<ITable> Tables
        {
            get 
            {
                if (_tableList == null)
                {
                    DataTable dtTables = getTableList();
                    _tableList = new List<ITable>();
                    foreach (DataRow rowTable in dtTables.Rows)
                    {
                        String tableName = rowTable["TABLE_NAME"].ToString();
                        TableSqlite table = new TableSqlite(this, template, tableName, this.Name);
                        _tableList.Add(table);
                    }
                }
                return _tableList;
                
            }
        }

        public DataTable getTableList()
        {
            DataTable dtTables = template.DataTableOlustur(TABLE_LIST_SQL);
            return dtTables;
        }


        public ITable getTable(string pTableName, string pSchemaName)
        {
            return new TableSqlite(this, template, pTableName, pSchemaName);
        }

        public override string ToString()
        {
            return string.Format("SqliteDatabase : {0}, ConnectionString: {1}", Name, connectionString);
        }


        public AdoTemplate Template
        {
            get { return template; }
            set { template = value; }
        }
        string databaseName;

        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }
        DatabaseSqlite database;


        public string getDatabaseName(AdoTemplate template)
        {
            return template.Connection.Database;
        }

        public string getDefaultSchema(AdoTemplate template)
        {
            return "";
        }

        public DataTable getTableListFromSchema(AdoTemplate template, string schemaName)
        {
            return database.getTableList();
        }

        public DataTable getSchemaList(AdoTemplate template)
        {
            return new DataTable();
        }

        public void CodeGenerateAllTables(AdoTemplate template
            , string pConnectionString
            , string pDatabaseName
            , string pProjectNamespace
            , string pProjectFolder
            , bool dboSemaTablolariniAtla
            , bool sysTablolariniAtla
            , bool semaIsminiSorgulardaKullan
            , bool semaIsminiDizinlerdeKullan
            , List<CodeGenerationHelper.DatabaseAbbreviations> listDatabaseAbbreviations)
        {
            DatabaseSqlite database = new DatabaseSqlite(template, pConnectionString, pDatabaseName, pProjectNamespace, pProjectFolder);

            foreach (ITable table in database.Tables)
            {
                CodeGenerateOneTable(
                    template
                    , pConnectionString
                    , table.Name
                    , table.Schema
                    , pDatabaseName
                    , pProjectNamespace
                    , pProjectFolder
                    , semaIsminiSorgulardaKullan
                    , semaIsminiDizinlerdeKullan
                    , listDatabaseAbbreviations);
            }


        }

        public void CodeGenerateOneTable(AdoTemplate template
            , string pConnectionString
            , string pTableName
            , string pSchemaName
            , string pDatabaseName
            , string pProjectNamespace
            , string pProjectFolder
            , bool semaIsminiSorgulardaKullan
            , bool semaIsminiDizinlerdeKullan
            , List<CodeGenerationHelper.DatabaseAbbreviations> listDatabaseAbbreviations)
        {
            if (pTableName.StartsWith("sqlite_"))
            {
                return;
            }

            TypeLibraryGenerator typeGen = new TypeLibraryGenerator(this);
            DalGenerator dalGen = this.DalGenerator;
            BsGenerator bsGen = new BsGenerator(this);
            IOutput output = new SqliteOutput();
            DatabaseSqlite database = new DatabaseSqlite(template, pConnectionString, pDatabaseName, pProjectNamespace, pProjectFolder);

            ITable table = database.getTable(pTableName, pSchemaName);


            typeGen.Render(output, table,semaIsminiSorgulardaKullan,semaIsminiDizinlerdeKullan, listDatabaseAbbreviations);
            dalGen.Render(output, table,semaIsminiSorgulardaKullan,semaIsminiDizinlerdeKullan, listDatabaseAbbreviations);
            bsGen.Render(output, table,semaIsminiSorgulardaKullan,semaIsminiDizinlerdeKullan, listDatabaseAbbreviations);
        }

        public DalGenerator DalGenerator
        {
            get { return new SqliteDalGenerator(this); }
        }

    }
}
