using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.Core.DataUtil;

namespace Karkas.CodeGeneration.Sqlite
{
    public class SqliteHelper : IDatabaseHelper
    {
        public string getDatabaseName(AdoTemplate template)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public CodeGenerationHelper.Generators.DalGenerator DalGenerator
        {
            get { throw new NotImplementedException(); }
        }
    }
}
