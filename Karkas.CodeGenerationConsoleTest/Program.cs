using System;
using System.Collections.Generic;
using System.Text;
using Karkas.CodeGenerationHelper;
using Karkas.CodeGenerationHelper.Generators;
using System.Configuration;
using Karkas.MyGenerationTest;
using Karkas.Core.DataUtil;
using Karkas.CodeGenerationHelper.SmoHelpers;
using Karkas.CodeGeneration.SqlServer;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.CodeGeneration.SqlServer.Implementations;
using Karkas.CodeGeneration.Oracle;
using System.Reflection;
using System.Runtime.Remoting;
using System.Data.Common;
using System.Data.SQLite;
using Karkas.CodeGeneration.Sqlite;
using Karkas.CodeGeneration.SqliteSupport.TypeLibrary.Karkas.CodeGeneration.SqliteSupport.TypeLibrary.Main;

namespace Karkas.MyGenerationConsoleTest
{
    public class Program
    {
        public const string _SqlServerExampleConnectionString = @"Data Source=localhost\SQLSERVER2012;Initial Catalog=KARKAS_ORNEK;Integrated Security=True";
        public const string _OracleExampleConnectionString = "Data Source=ORACLEDEVDAYS;Persist Security Info=True;User ID=hr;Password=hr;Unicode=True";
        public const string _SqliteExampleConnectionString = @"Data Source=P:\karkasGit\svn\codeGeneration\Karkas.CodeGeneration.WinApp\connectionsDb.sqlite";


        public static void Main(string[] args)
        {


            Console.WriteLine("atilla".Replace("a", "b"));  




            OracleTest();
            SqlServerTest();
            SqliteTest();
            //simpleSqliteConnectionTest();
        }

        private static void simpleSqliteConnectionTest()
        {
            try
            {

                SQLiteConnection conn;

                conn = new SQLiteConnection(_SqliteExampleConnectionString);

                conn.Open();
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                throw new Exception(ex.Message);

            }

        }

        private static void databaseGenerationTestGenerateAllTables(
            String assemblyName
            , String dbProviderName
            , String dbDatabaseType
            ,String connectionClassName
            ,String connectionString
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
            AdoTemplate template = new AdoTemplate();
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
            IDatabaseHelper helper = getDatabaseHelper( dbDatabaseType,template, pDatabaseName);
            helper.CodeGenerateAllTables(template,
                connectionString
                ,  pDatabaseName
                ,  pProjectNamespace
                ,  pProjectFolder
                ,  dboSemaTablolariniAtla
                ,  sysTablolariniAtla
                ,  semaIsminiSorgulardaKullan
                ,  listDatabaseAbbreviations
                
                );
        }


        public static IDatabaseHelper getDatabaseHelper(String databaseType,AdoTemplate template,String databaseName)
        {
            IDatabaseHelper helper = null;
            switch(databaseType)
            {
                case DatabaseType.SqlServer:
                    helper = new SqlServerHelper(template,databaseName);
                    break;
                case DatabaseType.Oracle:
                    helper = new OracleHelper(template,databaseName);
                    break;
                case DatabaseType.Sqlite:
                    helper = new SqliteHelper(template, databaseName);
                    break;
            }
            return helper;
        }



        private static void SqliteTest()
        {
            databaseGenerationTestGenerateAllTables(
                    "System.Data.SQLite"
                    , "System.Data.SQLite"
                    , DatabaseType.Sqlite
                    ,"System.Data.SQLite.SQLiteConnection"
                    ,_SqliteExampleConnectionString
                    , "main",
                    "Karkas.CodeGeneration.SqliteSupport"
                    , "P:\\Denemeler\\karkas\\Karkas.CodeGeneration.SqliteSupport"
                    , 
                    true,
                    true, 
                    true, 
                    null
                    );
        }

        private static void OracleTest()
        {

            databaseGenerationTestGenerateAllTables(
                    "System.Data.OracleClient"
                    , "System.Data.OracleClient"
                    , DatabaseType.Oracle
                    , "System.Data.OracleClient.OracleConnection"
                    , _OracleExampleConnectionString
                    ,"ORACLEDEVDAYS"
                    , "Karkas.OracleExample"
                    , "P:\\Denemeler\\karkas\\Examples\\Karkas.OracleExample"
                    , true
                    , true
                    , true
                    , null);

            }

        private static void SqlServerTest()
        {
            databaseGenerationTestGenerateAllTables(
                "System.Data"
                , "System.Data.SqlClient"
                , DatabaseType.SqlServer
                , "System.Data.SqlClient.SqlConnection"
                , _SqlServerExampleConnectionString
                , "KARKAS_ORNEK"
                , "Karkas.Ornek"
                , "P:\\Denemeler\\karkas\\Examples\\Karkas.Ornek"
                , true
                , true
                ,true
                ,null);

        }


    }
}

