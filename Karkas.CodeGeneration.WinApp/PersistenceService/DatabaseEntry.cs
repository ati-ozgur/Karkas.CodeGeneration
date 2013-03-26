using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Karkas.CodeGenerationHelper;

namespace Karkas.CodeGeneration.WinApp.PersistenceService
{
    public class DatabaseEntry 
    {
        public DatabaseEntry()
        {
            CreationTimeUtc = DateTime.UtcNow;
            LastAccessTimeUtc = DateTime.UtcNow;
            LastWriteTimeUtc = DateTime.UtcNow;
            AbbrevationsAsString = string.Empty;
        }


        public String ConnectionName;
        public DatabaseType ConnectionDatabaseType;
        public String AbbrevationsAsString;
        public String ConnectionString;
        public String CodeGenerationDirectory;
        public String CodeGenerationNamespace;
        public DateTime CreationTimeUtc;
        public DateTime LastAccessTimeUtc;
        public DateTime LastWriteTimeUtc;





        public override string ToString()
        {
            String str = string.Format("{0}\t{1}\t{2}\t{3}", ConnectionName, ConnectionDatabaseType, CodeGenerationNamespace, ConnectionString);
            return str;

        }




    }
}
