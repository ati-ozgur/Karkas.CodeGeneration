using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.Core.DataUtil;
using Karkas.CodeGenerationHelper.Generators;
using Karkas.CodeGeneration.Sqlite.Implementations;
using Karkas.CodeGeneration.Sqlite.Generators;
using System.Data;

namespace Karkas.CodeGeneration.Sqlite
{
    public class SqliteHelper : IDatabaseHelper
    {

        AdoTemplate template;
        string connectionString;
        string databaseName;
        DatabaseSqlite database;

        public SqliteHelper(AdoTemplate template, string pConnectionString, string pDatabaseName)
        {
            this.template = template;
            this.connectionString = pConnectionString;
            this.databaseName = pDatabaseName;
            this.database = new DatabaseSqlite(template, pConnectionString, pDatabaseName, "", "");
        }

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
            , List<CodeGenerationHelper.DatabaseAbbreviations> listDatabaseAbbreviations)
        {
            DatabaseSqlite database = new DatabaseSqlite(template, pConnectionString, pDatabaseName, pProjectNamespace, pProjectFolder);

            foreach (ITable table in database.Tables)
            {
                CodeGenerateOneTable(template, pConnectionString, table.Name, table.Schema, pDatabaseName, pProjectNamespace, pProjectFolder, semaIsminiSorgulardaKullan,listDatabaseAbbreviations);
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


            typeGen.Render(output, table,semaIsminiSorgulardaKullan, listDatabaseAbbreviations);
            dalGen.Render(output, table,semaIsminiSorgulardaKullan, listDatabaseAbbreviations);
            bsGen.Render(output, table,semaIsminiSorgulardaKullan, listDatabaseAbbreviations);
        }

        public DalGenerator DalGenerator
        {
            get { return new SqliteDalGenerator(this); }
        }
    }
}
