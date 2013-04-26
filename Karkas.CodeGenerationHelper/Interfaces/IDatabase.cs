using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.Core.DataUtil;
using System.Data;
using Karkas.CodeGenerationHelper.Generators;

namespace Karkas.CodeGenerationHelper.Interfaces
{
    public interface IDatabase
    {
        string Name { get; set; }
        string DatabaseName
        {
            get;
            set;
        }

        string ProjectNameSpace { get; }
        string ProjectFolder { get; }


        List<ITable> Tables { get; }

        ITable getTable(string pTableName, string pSchemaName);

        AdoTemplate Template
        {
            get;
            set;
        }




        string getDatabaseName();

        //string DatabaseNameLogical
        //{
        //    get;
        //}

        string getDefaultSchema();

        DataTable getTableListFromSchema(string schemaName);
        DataTable getSchemaList();

        void CodeGenerateAllTables(
             bool dboSemaTablolariniAtla
            , bool sysTablolariniAtla
            );

        void CodeGenerateOneTable(
             string pTableName
            , string pSchemaName
            );


        DalGenerator DalGenerator
        {
            get;
        }


        bool SemaIsminiSorgulardaKullan
        {
            get;
            set;
        }

        bool SemaIsminiDizinlerdeKullan
        {
            get;
            set;
        }

        List<DatabaseAbbreviations> ListDatabaseAbbreviations
        {
            get;
            set;
        }

    }
}
