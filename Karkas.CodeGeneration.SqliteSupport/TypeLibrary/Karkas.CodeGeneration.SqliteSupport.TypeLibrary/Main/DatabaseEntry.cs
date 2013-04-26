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
using Karkas.CodeGenerationHelper.Interfaces;

namespace Karkas.CodeGeneration.SqliteSupport.TypeLibrary.Main
{
    public partial class DatabaseEntry
    {

        public DatabaseEntry()
        {
            this.CreationTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            setTimeValues();
        }

        public override string ToString()
        {
            return this.ConnectionName + "," + this.ProjectNameSpace;
        }


        public void setTimeValues()
        {
            this.LastWriteTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"); ;
            this.LastAccessTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"); ;
            
        }


        public void setIDatabaseValues(IDatabase database)
        {
            database.CodeGenerationDirectory = this.CodeGenerationDirectory;
            database.ConnectionDatabaseType = this.ConnectionDatabaseType;
            database.ConnectionName = this.ConnectionName;
            database.ConnectionString = this.ConnectionString;
            database.DatabaseNameLogical = this.databaseNameLogical;
            database.DatabaseNamePhysical = this.DatabaseNameLogical;
            database.ConnectionDbProviderName = this.ConnectionDbProviderName;
            database.IgnoredSchemaList = this.IgnoredSchemaList;
            database.IgnoreSystemTables = Convert.ToBoolean(this.IgnoreSystemTables);
            database.ProjectNameSpace = this.ProjectNameSpace;
            database.StoredProcedureCodeGenerate = Convert.ToBoolean(this.StoredProcedureCodeGenerate);
            database.UseSchemaNameInFolders = Convert.ToBoolean(this.UseSchemaNameInFolders);
            database.UseSchemaNameInSqlQueries = Convert.ToBoolean(this.useSchemaNameInSqlQueries);
            database.ViewCodeGenerate = Convert.ToBoolean(this.ViewCodeGenerate);

        }

    }
}
