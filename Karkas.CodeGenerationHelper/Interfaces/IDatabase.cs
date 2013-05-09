﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.Core.DataUtil;
using System.Data;
using Karkas.CodeGenerationHelper.Generators;

namespace Karkas.CodeGenerationHelper.Interfaces
{
    public interface IDatabase : ICodeGenerationPersistanceValues, ICodeGenerationNotPersistedValues
    {

        List<DatabaseAbbreviations> ListDatabaseAbbreviations { get; set; }


        DataTable getSchemaList();

        string getDefaultSchema();

        AdoTemplate Template
        {
            get;
            set;
        }

        List<ITable> Tables { get; }
        DataTable getTableListFromSchema(string schemaName);
        DataTable getViewListFromSchema(string schemaName);

        ITable getTable(string pTableName, string pSchemaName);

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
