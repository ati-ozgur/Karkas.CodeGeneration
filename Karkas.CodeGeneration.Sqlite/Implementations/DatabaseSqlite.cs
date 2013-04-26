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

        public string ProjectNameSpace
        {
            get { return _projectNameSpace; }
        }

        public string ProjectFolder
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


        public string getDatabaseName()
        {
            return template.Connection.Database;
        }

        public string getDefaultSchema()
        {
            return "";
        }

        public DataTable getTableListFromSchema( string schemaName)
        {
            return database.getTableList();
        }

        public DataTable getSchemaList()
        {
            return new DataTable();
        }

        public void CodeGenerateAllTables(
             bool dboSemaTablolariniAtla
            , bool sysTablolariniAtla
            , bool semaIsminiSorgulardaKullan
            , bool semaIsminiDizinlerdeKullan
            , List<CodeGenerationHelper.DatabaseAbbreviations> listDatabaseAbbreviations)
        {

            foreach (ITable table in this.Tables)
            {
                CodeGenerateOneTable(
                     table.Name
                    , table.Schema
                    , semaIsminiSorgulardaKullan
                    , semaIsminiDizinlerdeKullan
                    , listDatabaseAbbreviations);
            }


        }

        public void CodeGenerateOneTable(
             string pTableName
            , string pSchemaName
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

            ITable table = getTable(pTableName, pSchemaName);


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
