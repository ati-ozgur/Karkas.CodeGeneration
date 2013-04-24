using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Collections.Generic;
using Karkas.Core.TypeLibrary;
using Karkas.Core.Onaylama;
using Karkas.Core.Onaylama.ForPonos;

namespace Karkas.CodeGeneration.SqliteSupport.TypeLibrary.Main
{
    public partial class DatabaseEntry
    {

        public DatabaseEntry()
        {
            this.CreationTime = DateTime.UtcNow.ToString("yyyy-MM-DD HH:mm:ss");
        }

        public override string ToString()
        {
            return this.ConnectionName + "," + this.CodeGenerationNamespace;
        }


        public void setTimeValues()
        {
            this.LastWriteTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"); ;
            this.LastAccessTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"); ;
            
        }

    }
}
