using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.Core.DataUtil;
using System.Data;

namespace Karkas.CodeGeneration.Sqlite.Implementations
{
    public class DatabaseSqlite : IDatabase
    {

        public DatabaseSqlite(AdoTemplate pTemplate, String pConnectionString, string pDatabaseName, string pProjectNameSpace, string pProjectFolder)
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

        private const string TABLE_LIST_SQL = @"SELECT name FROM sqlite_master
                                                WHERE type='table'
                                                ORDER BY name;";


        List<ITable> _tableList = null;

        public List<ITable> Tables
        {
            get 
            {
                if (_tableList == null)
                {
                    DataTable dtTables = template.DataTableOlustur(TABLE_LIST_SQL);
                    _tableList = new List<ITable>();
                    foreach (DataRow rowTable in dtTables.Rows)
                    {
                        String tableName = rowTable["name"].ToString();
                        TableSqlite table = new TableSqlite(this, template, tableName, this.Name);
                        _tableList.Add(table);
                    }
                }
                return _tableList;
                
            }
        }


        public ITable getTable(string pTableName, string pSchemaName)
        {
            return new TableSqlite(this, template, pTableName, pSchemaName);
        }

        public override string ToString()
        {
            return string.Format("SqliteDatabase : {0}, ConnectionString: {1}", Name, connectionString);
        }
    }
}
