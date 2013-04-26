using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;

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
            public string ProjeDizininiAl(IDatabase database)
            {
                return database.projectFolder;
            }
        }
	}
}
