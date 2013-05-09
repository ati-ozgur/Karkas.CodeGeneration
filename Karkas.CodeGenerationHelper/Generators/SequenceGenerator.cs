using System;
using System.Collections;
using System.Text;
using Karkas.CodeGenerationHelper;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using Karkas.CodeGenerationHelper.Interfaces;
using System.Collections.Generic;
using Karkas.CodeGenerationHelper.BaseClasses;

namespace Karkas.CodeGenerationHelper.Generators
{
    public class SequenceGenerator : BaseGenerator
    {

        string baseNameSpace = "";
        string baseNameSpaceTypeLibrary = "";

        public SequenceGenerator(IDatabase databaseHelper)
        {
            utils = new Utils(databaseHelper);
            this.database = databaseHelper;

        }
        Utils utils = null;
        IDatabase database;


        public string Render(IOutput output
            , string schemaName
            , string sequenceName)
        {
            output.tabLevel = 0;
            baseNameSpace = utils.NamespaceIniAlSchemaIle(database, schemaName);
            baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            string schemaNamepascalCase = utils.GetPascalCase(schemaName);
            string sequenceNamePascalCase = utils.GetPascalCase(sequenceName);

            string baseNameSpaceSequencesDal = baseNameSpace + ".Dal." + schemaNamepascalCase + ".Sequences";

            string sequenceDalName = sequenceNamePascalCase + "Dal";

            string outputFullFileNameGenerated = utils.FileUtilsHelper.getBaseNameForSequenceDalGenerated(database, schemaName, sequenceNamePascalCase, database.UseSchemaNameInFolders);

            UsingleriYaz(output,baseNameSpaceSequencesDal);
            ClassYaz(output, sequenceDalName);

            SelectSequenceStringYaz(output, database, schemaName, sequenceName);

            output.saveEncoding(outputFullFileNameGenerated, "o", "utf8");
            output.clear();
            return "";


        }

        private void SelectSequenceStringYaz(IOutput output, IDatabase database, string schemaName, string sequenceName)
        {
            output.autoTabLn("");
        }

        private void UsingleriYaz(IOutput output, string baseNameSpaceSequencesDal)
        {
            output.autoTabLn("");
            output.autoTabLn("using System;");
            output.autoTabLn("using System.Collections.Generic;");
            output.autoTabLn("using System.Data;");
            output.autoTabLn("using System.Data.Common;");
            output.autoTabLn("using System.Data.SqlClient;");
            output.autoTabLn("using System.Text;");
            output.autoTabLn("using Karkas.Core.DataUtil;");
            output.autoTab("using ");
            output.autoTabLn("");
            output.autoTabLn("");
            output.autoTab("namespace ");
            output.autoTab(baseNameSpaceSequencesDal);
            output.autoTabLn("");
            BaslangicSusluParentezVeTabArtir(output);
        }


        private void ClassYaz(IOutput output, string className)
        {
            output.autoTab("public partial class ");
            output.write(className);
            BaslangicSusluParentezVeTabArtir(output);
        }


    }
}

