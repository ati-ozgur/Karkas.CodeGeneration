using System;
using System.Collections.Generic;
using System.Text;
using Karkas.CodeGenerationHelper;
using Karkas.CodeGenerationHelper.Generators;
using System.Configuration;
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
using Karkas.CodeGeneration.Helper;

namespace Karkas.CodeGeneration.ConsoleTest
{
    public class Program
    {
        public const string _SqlServerExampleConnectionString = @"Data Source=localhost\SQLSERVER2012;Initial Catalog=KARKAS_ORNEK;Integrated Security=True";
        public const string _OracleExampleConnectionString = "Data Source=ORACLEDEVDAYS;Persist Security Info=True;User ID=hr;Password=hr;Unicode=True";
        public const string _SqliteExampleConnectionString = @"Data Source=P:\karkasGit\svn\codeGeneration\Karkas.CodeGeneration.WinApp\connectionsDb.sqlite";


        public static void Main(string[] args)
        {

            OracleTest();
            //SqliteTest();
            //SqlServerTest();
        }






        private static void SqliteTest()
        {
            CodeGenerationTestUtils.DatabaseGenerationTestGenerateAllTables(
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
                    true,
                    null
                    );
        }

        private static void OracleTest()
        {

            CodeGenerationTestUtils.DatabaseGenerationTestGenerateAllTables(
                    "System.Data.OracleClient"
                    , "System.Data.OracleClient"
                    , DatabaseType.Oracle
                    , "System.Data.OracleClient.OracleConnection"
                    , _OracleExampleConnectionString
                    ,"ORACLEDEVDAYS"
                    , "Karkas.OracleExample"
                    , @"P:\Denemeler\karkas\Examples\Karkas.OracleExample"
                    , true
                    , true
                    , false
                    , false
                    , null);

            }

        private static void SqlServerTest()
        {
            CodeGenerationTestUtils.DatabaseGenerationTestGenerateAllTables(
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
                , true
                ,null);

        }


    }
}

