using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.Core.DataUtil;
using System.Data;

namespace Karkas.CodeGeneration.Sqlite.Implementations
{
    public class TableSqlite : ITable
    {

        public TableSqlite(DatabaseSqlite pDatabase, AdoTemplate template, String pTableName, String pSchemaName)
        {
            this.database = pDatabase;
            this.template = template;
            this.tableName = pTableName;
            this.schemaName = pSchemaName;
        }

        DatabaseSqlite database;

        AdoTemplate template;
        String tableName;
        String schemaName;

        public int findIndexFromName(string name)
        {
            throw new NotImplementedException();
        }


        private Decimal? primaryKeyColumnCount = null;
        public int PrimaryKeyColumnCount
        {
            get 
            {
                if (!primaryKeyColumnCount.HasValue)
                {
                    throw new NotImplementedException();

                }
                return (int) primaryKeyColumnCount.Value;

            }
        }

        public bool HasPrimaryKey
        {
            get { return PrimaryKeyColumnCount > 0; }
        }

        public string Alias
        {
            get { throw new NotImplementedException(); }
        }

        public List<IColumn> columns = null;




        public List<IColumn> Columns
        {
            get 
            {
                if (columns == null)
                {
                    throw new NotImplementedException();
                }
                return columns;
            }
        }

        public IDatabase Database
        {
            get 
            {
                return database;
            
            }
        }

        public DateTime DateCreated
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime DateModified
        {
            get { throw new NotImplementedException(); }
        }

        public string Description
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { return tableName; }
        }

        public string Schema
        {
            get { return schemaName; }
        }
    }
}
