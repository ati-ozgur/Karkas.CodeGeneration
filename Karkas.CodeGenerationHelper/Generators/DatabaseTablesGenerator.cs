using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Karkas.CodeGenerationHelper.SmoHelpers;
using Karkas.CodeGenerationHelper.Interfaces;

namespace Karkas.CodeGenerationHelper.Generators
{
    public class DatabaseTablesGenerator
    {
        SmoHelper smoHelper = new SmoHelper();
        InsertScriptHelper insertHelper = new InsertScriptHelper();

        public void Render(IOutput output, ITable table, string connectionString)
        {
            Utils utils = new Utils(null);

            output.writeLine(smoHelper.GetTableDescription(table.Database.Name, table.Schema, table.Name, connectionString));
            output.save(utils.FileUtilsHelper.getCreateScriptsFullName(table), false);
            output.clear();

            output.writeLine(smoHelper.GetTableRelationDescriptions(table.Database.Name, table.Schema, table.Name, connectionString));
            output.save(utils.FileUtilsHelper.getCreateRelationScriptsFullName(table), false);
            output.clear();
        }

    }
}
