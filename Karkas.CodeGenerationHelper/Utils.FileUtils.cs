using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using System.IO;

namespace Karkas.CodeGenerationHelper
{
    public partial class Utils
    {
        public FileUtils FileUtilsHelper
        {
            get
            {
                return new FileUtils();
            }
        }


        public class FileUtils
        {
            public string ProjeAnaDizininiAl(IDatabase database)
            {
                return database.projectFolder;
            }

            public string getBaseNameForDalGenerated(IDatabase database,string schemaName,bool semaIsminiDizinlerdeKullan)
            {
                if (semaIsminiDizinlerdeKullan)
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\Dal\\" + database.projectNameSpace + ".Dal\\" + schemaName, database.projectNameSpace + "Dal.generated.cs");
                }
                else
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\Dal\\" + database.projectNameSpace + ".Dal\\" , database.projectNameSpace + "Dal.generated.cs");
                }
            }





        }
	}
}
