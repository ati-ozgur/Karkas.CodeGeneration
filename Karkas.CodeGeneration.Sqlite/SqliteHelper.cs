using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.Core.DataUtil;
using Karkas.CodeGenerationHelper.Generators;
using Karkas.CodeGeneration.Sqlite.Implementations;
using Karkas.CodeGeneration.Sqlite.Generators;

namespace Karkas.CodeGeneration.Sqlite
{
    public class SqliteHelper : IDatabaseHelper
    {
        public string getDatabaseName(AdoTemplate template)
        {
            return template.Connection.Database;
        }

        public string getDefaultSchema(AdoTemplate template)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable getTableListFromSchema(AdoTemplate template, string schemaName)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable getSchemaList(AdoTemplate template)
        {
            throw new NotImplementedException();
        }

        public void CodeGenerateAllTables(AdoTemplate template, string pConnectionString, string pDatabaseName, string pProjectNamespace, string pProjectFolder, bool dboSemaTablolariniAtla, bool sysTablolariniAtla, List<CodeGenerationHelper.DatabaseAbbreviations> listDatabaseAbbreviations)
        {
            throw new NotImplementedException();
        }

        public void CodeGenerateOneTable(AdoTemplate template, string pConnectionString, string pTableName, string pSchemaName, string pDatabaseName, string pProjectNamespace, string pProjectFolder, List<CodeGenerationHelper.DatabaseAbbreviations> listDatabaseAbbreviations)
        {
            TypeLibraryGenerator typeGen = new TypeLibraryGenerator(this);
            DalGenerator dalGen = this.DalGenerator;
            BsGenerator bsGen = new BsGenerator(this);
            IOutput output = new SqliteOutput();
            DatabaseSqlite database = new DatabaseSqlite(template, pConnectionString, pDatabaseName, pProjectNamespace, pProjectFolder);

            ITable table = database.getTable(pTableName, pSchemaName);


            typeGen.Render(output, table, listDatabaseAbbreviations);
            dalGen.Render(output, table, listDatabaseAbbreviations);
            bsGen.Render(output, table, listDatabaseAbbreviations);
        }

        public DalGenerator DalGenerator
        {
            get { return new SqliteDalGenerator(this); }
        }
    }
}
