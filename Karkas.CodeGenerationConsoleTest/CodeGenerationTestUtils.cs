using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Karkas.Core.DataUtil;
using System.Reflection;
using System.Runtime.Remoting;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.CodeGenerationHelper;
using Karkas.CodeGeneration.SqlServer;
using Karkas.CodeGeneration.Oracle;
using Karkas.CodeGeneration.Sqlite;

namespace Karkas.CodeGeneration.Helper
{
    public class CodeGenerationTestUtils
    {

        public static void DatabaseGenerationTestGenerateAllTables(
            String assemblyName
            , String dbProviderName
            , String dbDatabaseType
            , String connectionClassName
            , String connectionString
            , string pDatabaseName
            , string pProjectNamespace
            , string pProjectFolder
            , bool dboSemaTablolariniAtla
            , bool sysTablolariniAtla
            , bool semaIsminiSorgulardaKullan
            , List<DatabaseAbbreviations> listDatabaseAbbreviations
            )
        {
            DbConnection connection = null;
            AdoTemplate template = null;
            Assembly oracleAssembly = Assembly.LoadWithPartialName(assemblyName);
            Object objReflection = Activator.CreateInstance(oracleAssembly.FullName, connectionClassName);

            if (objReflection != null && objReflection is ObjectHandle)
            {
                ObjectHandle handle = (ObjectHandle)objReflection;

                Object objConnection = handle.Unwrap();
                connection = (DbConnection)objConnection;
                connection.ConnectionString = connectionString;
                connection.Open();
                connection.Close();
                template = new AdoTemplate();
                template.Connection = connection;
                template.DbProviderName = assemblyName;
            }
            IDatabaseHelper helper = getDatabaseHelper(dbDatabaseType, template, pDatabaseName);
            helper.CodeGenerateAllTables(template,
                connectionString
                , pDatabaseName
                , pProjectNamespace
                , pProjectFolder
                , dboSemaTablolariniAtla
                , sysTablolariniAtla
                , semaIsminiSorgulardaKullan
                , listDatabaseAbbreviations

                );
        }


        public static IDatabaseHelper getDatabaseHelper(String databaseType, AdoTemplate template, String databaseName)
        {
            IDatabaseHelper helper = null;
            switch (databaseType)
            {
                case DatabaseType.SqlServer:
                    helper = new SqlServerHelper(template, databaseName);
                    break;
                case DatabaseType.Oracle:
                    helper = new OracleHelper(template, databaseName);
                    break;
                case DatabaseType.Sqlite:
                    helper = new SqliteHelper(template, databaseName);
                    break;
            }
            return helper;
        }
    }
}
