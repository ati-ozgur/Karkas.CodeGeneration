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
        string ProjectNameSpace { get; }
        string ProjectFolder { get; }

        string getDatabaseNamePhysical();

        string DatabaseNameLogical
        {
            get;
            set;
        }

        string getDefaultSchema();

        //string DatabaseNameLogical
        //{
        //    get;
        //}

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

        bool DboSemaTablolariniAtla
        {
            get;
            set;
        }
        bool SysTablolariniAtla
        {
            get;
            set;
        }




        
        DataTable getSchemaList();



        AdoTemplate Template
        {
            get;
            set;
        }

        List<ITable> Tables { get; }

        ITable getTable(string pTableName, string pSchemaName);






        DataTable getTableListFromSchema(string schemaName);

        void CodeGenerateAllTables();

        void CodeGenerateOneTable(
             string pTableName
            , string pSchemaName
            );


        DalGenerator DalGenerator
        {
            get;
        }





    }
}
