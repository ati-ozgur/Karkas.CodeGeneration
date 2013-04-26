﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.CodeGenerationHelper;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using Karkas.CodeGenerationHelper.Generators;
using Karkas.Core.DataUtil;
using System.Data;
using Karkas.CodeGeneration.SqlServer.Generators;


namespace Karkas.CodeGeneration.SqlServer.Implementations
{
    public class DatabaseSqlServer : IDatabase
    {
        internal Server smoServer;
        internal Database smoDatabase;
        internal string connectionString;

        string _projectFolder;

        public DatabaseSqlServer(
            AdoTemplate template
            , String pConnectionString
            ,string pDatabaseName
            ,string pProjectNameSpace
            ,string pProjectFolder
            ,bool semaIsminiSorgulardaKullan
            ,bool semaIsminiDizinlerdeKullan
            , bool dboSemaTablolariniAtla
            , bool sysTablolariniAtla
            , List<DatabaseAbbreviations> listDatabaseAbbreviations
            
            )
        {
            this.template = template;
            connectionString = ConnectionHelper.RemoveProviderFromConnectionString(pConnectionString);
            smoServer = new Server(new ServerConnection(new SqlConnection(connectionString)));
            smoDatabase = smoServer.Databases[pDatabaseName];
            this.projectNameSpace = pProjectNameSpace;
            _projectFolder = pProjectFolder;
            this.semaIsminiSorgulardaKullan = semaIsminiSorgulardaKullan;
            this.semaIsminiDizinlerdeKullan = semaIsminiDizinlerdeKullan;
            this.listDatabaseAbbreviations = listDatabaseAbbreviations;
            this.dboSemaTablolariniAtla = dboSemaTablolariniAtla;
            this.sysTablolariniAtla = sysTablolariniAtla;

        }

        bool dboSemaTablolariniAtla;

        public bool DboSemaTablolariniAtla
        {
            get { return dboSemaTablolariniAtla; }
            set { dboSemaTablolariniAtla = value; }
        }
        bool sysTablolariniAtla;

        public bool SysTablolariniAtla
        {
            get { return sysTablolariniAtla; }
            set { sysTablolariniAtla = value; }
        }


        bool semaIsminiSorgulardaKullan;

        public bool SemaIsminiSorgulardaKullan
        {
            get { return semaIsminiSorgulardaKullan; }
            set { semaIsminiSorgulardaKullan = value; }
        }
        bool semaIsminiDizinlerdeKullan;

        public bool SemaIsminiDizinlerdeKullan
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

        private string projectNameSpace;

        public string ProjectNameSpace
        {
            get
            {
                return projectNameSpace;
            }
        }

        public string ProjectFolder
        {
            get
            {
                return _projectFolder;
            }
        }


        AdoTemplate template;

        public AdoTemplate Template
        {
            get { return template; }
            set { template = value; }
        }
        string databaseName;

        public string DatabaseNameLogical
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Name
        {
            get
            {
                return smoDatabase.Name;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        List<ITable> _tableList;

        public List<ITable> Tables
        {
           
            get 
            {
                if (_tableList == null)
                {
                    _tableList = new List<ITable>();
                    foreach (Table smoTable in smoDatabase.Tables)
                    {
                        ITable t = new TableSqlServer(this, smoTable.Name, smoTable.Schema);
                        _tableList.Add(t);
                    }
                }
                return _tableList;
            
            }
        }

        public override string ToString()
        {
            return Name;
        }


        public ITable getTable(string pTableName, string pSchemaName)
        {
             ITable t = new TableSqlServer(this, pTableName, pSchemaName);
             return t;
        }







        private const string SQL__FOR_SCHEMA_LIST = @"
SELECT '__TUM_SCHEMALAR__' AS TABLE_SCHEMA FROM INFORMATION_SCHEMA.TABLES
UNION
SELECT DISTINCT TABLE_SCHEMA FROM INFORMATION_SCHEMA.TABLES
";



        private const string SQL_FOR_TABLE_LIST = @"
SELECT TABLE_SCHEMA,TABLE_NAME, TABLE_SCHEMA + '.' + TABLE_NAME AS FULL_TABLE_NAME FROM INFORMATION_SCHEMA.TABLES
WHERE
( (@TABLE_SCHEMA IS NULL) OR (@TABLE_SCHEMA = '__TUM_SCHEMALAR__') OR ( TABLE_SCHEMA = @TABLE_SCHEMA))
AND
TABLE_TYPE = 'BASE TABLE'
ORDER BY FULL_TABLE_NAME
";

        private const string SQL_FOR_DATABASE_NAME = @"
SELECT DISTINCT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES
";

        public string getDatabaseNamePhysical()
        {
            return (string)template.TekDegerGetir(SQL_FOR_DATABASE_NAME);
        }

        public DataTable getTableListFromSchema(string schemaName)
        {
            ParameterBuilder builder = new ParameterBuilder();
            builder.parameterEkle("@TABLE_SCHEMA", DbType.String, schemaName);
            DataTable dtTableList = template.DataTableOlustur(SQL_FOR_TABLE_LIST, builder.GetParameterArray());
            return dtTableList;
        }

        public DataTable getSchemaList()
        {
            return template.DataTableOlustur(SQL__FOR_SCHEMA_LIST);
        }




        public void CodeGenerateAllTables()
        {
            TypeLibraryGenerator typeGen = new TypeLibraryGenerator(this);
            DalGenerator dalGen = this.DalGenerator;
            BsGenerator bsGen = new BsGenerator(this);
            IOutput output = new SqlServerOutput();

            List<ITable> tableListesi = this.Tables;

            foreach (ITable table in tableListesi)
            {
                if (dboSemaTablolariniAtla && table.Schema == "dbo")
                {
                    continue;
                }
                if (sysTablolariniAtla && (table.Name.StartsWith("sys") || table.Name == "dtproperties"))
                {
                    continue;
                }
                typeGen.Render(output, table, semaIsminiSorgulardaKullan, semaIsminiDizinlerdeKullan,listDatabaseAbbreviations);
                dalGen.Render(output, table, semaIsminiSorgulardaKullan, semaIsminiDizinlerdeKullan, listDatabaseAbbreviations);
                bsGen.Render(output, table, semaIsminiSorgulardaKullan, semaIsminiDizinlerdeKullan,listDatabaseAbbreviations);
            }
        }

        public void CodeGenerateOneTable(
             string pTableName
            , string pSchemaName
            )
        {
            TypeLibraryGenerator typeGen = new TypeLibraryGenerator(this);
            DalGenerator dalGen = this.DalGenerator;
            BsGenerator bsGen = new BsGenerator(this);
            IOutput output = new SqlServerOutput();

            ITable table = this.getTable(pTableName, pSchemaName);

            typeGen.Render(output, table, semaIsminiSorgulardaKullan, semaIsminiDizinlerdeKullan,listDatabaseAbbreviations);
            dalGen.Render(output, table, semaIsminiSorgulardaKullan,semaIsminiDizinlerdeKullan, listDatabaseAbbreviations);
            bsGen.Render(output, table, semaIsminiSorgulardaKullan, semaIsminiDizinlerdeKullan,listDatabaseAbbreviations);
        }






        public DalGenerator DalGenerator
        {
            get { return new SqlServerDalGenerator(this); }
        }


        public string getDefaultSchema()
        {
            return "dbo";
        }

    }
}
