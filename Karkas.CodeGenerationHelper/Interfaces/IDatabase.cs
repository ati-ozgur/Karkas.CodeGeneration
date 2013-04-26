﻿using System;
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

        string projectNameSpace { get; }
        string projectFolder { get; }


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
             string pDatabaseName
            , string pProjectNamespace
            , string pProjectFolder
            , bool dboSemaTablolariniAtla
            , bool sysTablolariniAtla
            , bool semaIsminiSorgulardaKullan
            , bool semaIsminiDizinlerdeKullan
            , List<DatabaseAbbreviations> listDatabaseAbbreviations
            );

        void CodeGenerateOneTable(
             string pTableName
            , string pSchemaName
            , string pDatabaseName
            , string pProjectNamespace
            , string pProjectFolder
            , bool semaIsminiSorgulardaKullan
            , bool semaIsminiDizinlerdeKullan
            , List<DatabaseAbbreviations> listDatabaseAbbreviations
            );


        DalGenerator DalGenerator
        {
            get;
        }

    }
}
