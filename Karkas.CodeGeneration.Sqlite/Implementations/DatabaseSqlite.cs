﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.Core.DataUtil;
using System.Data;
using Karkas.CodeGenerationHelper.Generators;
using Karkas.CodeGeneration.Sqlite.Generators;
using Karkas.CodeGenerationHelper;

namespace Karkas.CodeGeneration.Sqlite.Implementations
{
    public class DatabaseSqlite : IDatabase
    {
        


        public DatabaseSqlite(AdoTemplate template
            , String connectionString
            , string connectionName
            , string projectNameSpace
            , string codeGenerationDirectory
            , string dbProviderName
            , bool semaIsminiSorgulardaKullan
            , bool semaIsminiDizinlerdeKullan
            , bool sysTablolariniAtla
            , List<DatabaseAbbreviations> listDatabaseAbbreviations

            )
        {
            this.template = template;

            this.connectionString = connectionString;

            this.projectNameSpace = projectNameSpace;
            this.codeGenerationDirectory = codeGenerationDirectory;
            this.connectionName = connectionName;

            this.dbProviderName = dbProviderName;
            this.semaIsminiSorgulardaKullan = semaIsminiSorgulardaKullan;
            this.semaIsminiDizinlerdeKullan = semaIsminiDizinlerdeKullan;
            this.listDatabaseAbbreviations = listDatabaseAbbreviations;

            this.sysTablolariniAtla = sysTablolariniAtla;

        }


        bool sysTablolariniAtla;

        public bool IgnoreSystemTables
        {
            get { return sysTablolariniAtla; }
            set { sysTablolariniAtla = value; }
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

        string dbProviderName;

        public string ConnectionDbProviderName
        {
            get { return dbProviderName; }
            set { dbProviderName = value; }
        }


        bool semaIsminiSorgulardaKullan;

        public bool UseSchemaNameInSqlQueries
        {
            get { return semaIsminiSorgulardaKullan; }
            set { semaIsminiSorgulardaKullan = value; }
        }
        bool semaIsminiDizinlerdeKullan;

        public bool UseSchemaNameInFolders
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
        string projectNameSpace;
        string codeGenerationDirectory;
        string connectionName;


        string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }


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

        public string ProjectNameSpace
        {
            get { return projectNameSpace; }
            set { projectNameSpace = value; }

        }

        public string CodeGenerationDirectory
        {
            get { return codeGenerationDirectory; }
            set { codeGenerationDirectory = value; }
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
                        TableSqlite table = new TableSqlite(this, template, tableName, this.ConnectionName);
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
            return string.Format("SqliteDatabase : {0}, ConnectionString: {1}", ConnectionName, connectionString);
        }


        public AdoTemplate Template
        {
            get { return template; }
            set { template = value; }
        }
        string databaseName;

        public string DatabaseNameLogical
        {
            get { return databaseName; }
            set { databaseName = value; }
        }



        private string databaseNamePhysical;

        public string DatabaseNamePhysical
        {
            get
            {
                if (String.IsNullOrEmpty(databaseNamePhysical))
                {
                    databaseNamePhysical = template.Connection.Database; ;
                }
                return databaseNamePhysical;
            }
            set
            {
                databaseNamePhysical = value;
            }

        }


        public string getDefaultSchema()
        {
            return "";
        }

        public DataTable getTableListFromSchema( string schemaName)
        {
            return getTableList();
        }

        public DataTable getSchemaList()
        {
            return new DataTable();
        }

        public void CodeGenerateAllTables()
        {

            foreach (ITable table in this.Tables)
            {
                CodeGenerateOneTable(
                     table.Name
                    , table.Schema
                    );
            }


        }

        public void CodeGenerateOneTable(
             string pTableName
            , string pSchemaName
            )
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
