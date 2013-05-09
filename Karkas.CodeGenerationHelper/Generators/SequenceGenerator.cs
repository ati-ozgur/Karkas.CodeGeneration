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

            OverrideDbProviderNameYaz(output);



            SelectSequenceStringYaz(output, database, schemaName, sequenceName);
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);

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
            output.autoTabLn("");
            output.autoTab("namespace ");
            output.autoTab(baseNameSpaceSequencesDal);
            output.autoTabLn("");
            BaslangicSusluParentezVeTabArtir(output);
        }


        private void ClassYaz(IOutput output, string className)
        {
            output.increaseTab();
            output.autoTab("public partial class ");
            output.write(className);
            output.writeLine("");
            BaslangicSusluParentezVeTabArtir(output);
        }

        private void OverrideDbProviderNameYaz(IOutput output)
        {
            output.autoTabLn("public override string DbProviderName");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn(string.Format("return \"{0}\";", database.ConnectionDbProviderName));
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }

    }
}

