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
using Karkas.CodeGeneration.SqlServer.Implementations;
using Karkas.CodeGeneration.Oracle.Implementations;
using Karkas.CodeGeneration.Sqlite.Implementations;

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
            , string databaseName
            , string projectNamespace
            , string projectFolder
            , bool dboSemaTablolariniAtla
            , bool sysTablolariniAtla
            , bool semaIsminiSorgulardaKullan
            , bool semaIsminiDizinlerdeKullan
            , List<DatabaseAbbreviations> listDatabaseAbbreviations
            )
        {
            AdoTemplate template = null;
            DbConnection connection = TestAndGetConnection(assemblyName, connectionClassName, connectionString);
            template = new AdoTemplate();
            template.Connection = connection;
            template.DbProviderName = assemblyName;
            IDatabase helper = getDatabaseHelper(dbDatabaseType, 
                template, connectionString
                ,databaseName
                ,projectNamespace
                ,projectFolder
                ,semaIsminiDizinlerdeKullan
                ,semaIsminiSorgulardaKullan
                ,dboSemaTablolariniAtla
                ,sysTablolariniAtla
                );

            helper.CodeGenerateAllTables();
        }

        public static DbConnection TestAndGetConnection(String assemblyName, String connectionClassName, String connectionString)
        {
            DbConnection connection = null;
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
            }
            return connection;
        }


        public static IDatabase getDatabaseHelper(String databaseType
            , AdoTemplate template
            ,string connectionString
            , String databaseName
            ,string projectNamespace
            , string projectFolder
            , bool semaIsminiSorgulardaKullan
            , bool semaIsminiDizinlerdeKullan
            , bool dboSemaTablolariniAtla
            , bool sysTablolariniAtla
            )
        {
            IDatabase helper = null;
            switch (databaseType)
            {
                case DatabaseType.SqlServer:
                    helper = new DatabaseSqlServer(template, connectionString, databaseName, projectNamespace, projectFolder, semaIsminiSorgulardaKullan, semaIsminiDizinlerdeKullan, dboSemaTablolariniAtla,sysTablolariniAtla, null);
                    break;
                case DatabaseType.Oracle:
                    helper = new DatabaseOracle(template, connectionString, databaseName, projectNamespace, projectFolder, semaIsminiSorgulardaKullan, semaIsminiDizinlerdeKullan, dboSemaTablolariniAtla, sysTablolariniAtla, null);
                    break;
                case DatabaseType.Sqlite:
                    helper = new DatabaseSqlite(template, connectionString, databaseName, projectNamespace, projectFolder, semaIsminiSorgulardaKullan, semaIsminiDizinlerdeKullan, dboSemaTablolariniAtla, sysTablolariniAtla, null);
                    break;
            }
            return helper;
        }
    }
}
