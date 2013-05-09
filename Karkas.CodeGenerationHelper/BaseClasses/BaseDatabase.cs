using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.Core.DataUtil;
using System.Data;
using Karkas.CodeGenerationHelper.Generators;

namespace Karkas.CodeGenerationHelper.BaseClasses
{
    public abstract class BaseDatabase : IDatabase
    {
        bool sysTablolariniAtla;

        public bool IgnoreSystemTables
        {
            get { return sysTablolariniAtla; }
            set { sysTablolariniAtla = value; }
        }

        string connectionDatabaseType;

        public string ConnectionDatabaseType
        {
            get
            {
                return connectionDatabaseType;
            }
            set
            {
                connectionDatabaseType = value;
            }
        }

        string dbProviderName;

        public string ConnectionDbProviderName
        {
            get { return dbProviderName; }
            set { dbProviderName = value; }
        }


        bool semaIsminiSorgulardaKullan;

        public bool UseSchemaNameInSqlQueries
        {
            get { return semaIsminiSorgulardaKullan; }
            set { semaIsminiSorgulardaKullan = value; }
        }
        bool semaIsminiDizinlerdeKullan;

        public bool UseSchemaNameInFolders
        {
            get { return semaIsminiDizinlerdeKullan; }
            set { semaIsminiDizinlerdeKullan = value; }
        }
        List<DatabaseAbbreviations> listDatabaseAbbreviations;

        public List<DatabaseAbbreviations> ListDatabaseAbbreviations
        {
            get { return listDatabaseAbbreviations; }
            set { listDatabaseAbbreviations = value; }
        }


        private AdoTemplate template;
        string projectNameSpace;
        string codeGenerationDirectory;
        string connectionName;


        string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }


        public string ConnectionName
        {
            get
            {
                return connectionName;
            }
            set
            {
                connectionName = value;
            }
        }

        public string ProjectNameSpace
        {
            get { return projectNameSpace; }
            set { projectNameSpace = value; }

        }

        public string CodeGenerationDirectory
        {
            get { return codeGenerationDirectory; }
            set { codeGenerationDirectory = value; }
        }

        bool viewCodeGenerateEtsinMi;

        public bool ViewCodeGenerate
        {
            get { return viewCodeGenerateEtsinMi; }
            set { viewCodeGenerateEtsinMi = value; }
        }
        bool storedProcedureCodeGenerateEtsinMi;

        public bool StoredProcedureCodeGenerate
        {
            get { return storedProcedureCodeGenerateEtsinMi; }
            set { storedProcedureCodeGenerateEtsinMi = value; }
        }
        bool sequenceCodeGenerate;
        public bool SequenceCodeGenerate
        {
            get { return sequenceCodeGenerate; }
            set { sequenceCodeGenerate = value; }
        }


        string ignoredSchemaList;

        public string IgnoredSchemaList
        {
            get { return ignoredSchemaList; }
            set { ignoredSchemaList = value; }
        }
        string databaseAbbreviations;

        public string DatabaseAbbreviations
        {
            get { return databaseAbbreviations; }
            set { databaseAbbreviations = value; }
        }

        public AdoTemplate Template
        {
            get { return template; }
            set { template = value; }
        }
        string databaseName;

        public virtual string DatabaseNameLogical
        {
            get { return databaseName; }
            set { databaseName = value; }
        }



        private string databaseNamePhysical;

        public virtual string DatabaseNamePhysical
        {
            get
            {
                if (String.IsNullOrEmpty(databaseNamePhysical))
                {
                    databaseNamePhysical = template.Connection.Database; ;
                }
                return databaseNamePhysical;
            }
            set
            {
                databaseNamePhysical = value;
            }

        }

        public abstract List<ITable> Tables { get; }
        public abstract DataTable getTableListFromSchema(string schemaName);
        public abstract DataTable getViewListFromSchema(string schemaName);
        public abstract DataTable getStoredProcedureListFromSchema(string schemaName);
        public abstract DataTable getSequenceListFromSchema(string schemaName);
        

        public abstract ITable getTable(string pTableName, string pSchemaName);

        public abstract void CodeGenerateAllTables();
        public abstract void CodeGenerateOneTable(
             string pTableName
            , string pSchemaName
            );
        public abstract void CodeGenerateOneSequence(string sequenceName, string schemaName);


        public  abstract DalGenerator DalGenerator
        {
            get;
        }
        public abstract DataTable getSchemaList();

        public abstract string getDefaultSchema();


        #region "Not Persisted Values"
        public bool AnaSinifiTekrarUret { get; set; }
        public bool AnaSinifOnaylamaOrnekleriUret { get; set; }

        #endregion
    }
}
