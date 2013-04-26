﻿using System;
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

            public string getCreateRelationScriptsFullName(ITable table)
            {
                return Path.Combine(ProjeAnaDizininiAl(table.Database) + "\\Database\\CreateRelationScripts\\" + table.Schema, table.Schema + "_" + table.Name + ".Relations.sql");
            }

            public  string getCreateScriptsFullName(ITable table)
            {
                return Path.Combine(ProjeAnaDizininiAl(table.Database) + "\\Database\\CreateScripts\\" + table.Schema, table.Schema + "_" + table.Name + ".CreateTable.sql");
            }


            public string getBaseNameForBsGenerated(IDatabase database, string schemaName, bool semaIsminiDizinlerdeKullan)
            {
                if (semaIsminiDizinlerdeKullan)
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\Bs\\" + database.projectNameSpace + ".Bs\\" + schemaName, database.projectNameSpace + "Bs.generated.cs");
                }
                else
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\Bs\\" + database.projectNameSpace + ".Bs\\", database.projectNameSpace + "Bs.generated.cs");
                }
            }
            public string getBaseNameForBs(IDatabase database, string schemaName, bool semaIsminiDizinlerdeKullan)
            {
                if (semaIsminiDizinlerdeKullan)
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\Bs\\" + database.projectNameSpace + ".Bs\\" + schemaName, database.projectNameSpace + "Bs.cs");
                }
                else
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\Bs\\" + database.projectNameSpace + ".Bs\\", database.projectNameSpace + "Bs.cs");
                }
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
            public string getBaseNameForDal(IDatabase database,string schemaName,bool semaIsminiDizinlerdeKullan)
            {
                if (semaIsminiDizinlerdeKullan)
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\Dal\\" + database.projectNameSpace + ".Dal\\" + schemaName, database.projectNameSpace + "Dal.cs");
                }
                else
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\Dal\\" + database.projectNameSpace + ".Dal\\" , database.projectNameSpace + "Dal.cs");
                }
            }




            public string getInsertScriptsFullFileName(ITable table)
            {
                return Path.Combine(ProjeAnaDizininiAl(table.Database) + "\\Database\\InsertScripts\\" + table.Schema, table.Schema + "_" + table.Name + ".Inserts.sql");
            }



        }
	}
}
