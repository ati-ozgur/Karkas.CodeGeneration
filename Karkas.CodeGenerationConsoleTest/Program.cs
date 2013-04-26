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
using Karkas.CodeGeneration.Oracle.Implementations;

namespace Karkas.CodeGeneration.ConsoleTest
{
    public class Program
    {
        public const string _SqlServerExampleConnectionString = @"Data Source=localhost\SQLSERVER2012;Initial Catalog=KARKAS_ORNEK;Integrated Security=True";
        public const string _OracleExampleConnectionString = "Data Source=DEVELOPMENT;Persist Security Info=True;User ID=hr;Password=hr;Unicode=True";
        public const string _SqliteExampleConnectionString = @"Data Source=P:\github\karkas\codeGeneration\Karkas.CodeGeneration.WinApp\connectionsDb.sqlite";


        public static void Main(string[] args)
        {

           // OracleTestHr();
            OracleTestHr2();
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
                    , @"P:\denemeler\karkas\ornekler\Karkas.Ornek.SqliteOrnek"
                    , 
                    true,
                    true, 
                    false,
                    false,
                    null
                    );
        }

        private static void OracleTestHr2()
        {

            AdoTemplate template = CodeGenerationTestUtils.getTemplate("System.Data.OracleClient", "System.Data.OracleClient.OracleConnection", _OracleExampleConnectionString);

            IDatabase database = new DatabaseOracle(template);

            database.CodeGenerationDirectory = @"P:\github\Karkas.Ornek.OracleOrnek.Hr";
            database.ConnectionDatabaseType = "Oracle";
            database.ConnectionName = "Karkas.Ornek.OracleOrnek.Hr";
            database.ConnectionString = _OracleExampleConnectionString;
            database.DatabaseNameLogical = "OracleDevelopmentHr";
            database.DatabaseNamePhysical = "orcl";
            database.ConnectionDbProviderName = "System.Data.OracleClient";
            database.IgnoredSchemaList = "";
            database.IgnoreSystemTables = true;
            database.ProjectNameSpace = "Karkas.Ornek.OracleOrnek.Hr";
            database.StoredProcedureCodeGenerate = false;
            database.UseSchemaNameInFolders = false;
            database.UseSchemaNameInSqlQueries = false;
            database.ViewCodeGenerate = false;

            database.CodeGenerateAllTables();

        }

        private static void OracleTestHr()
        {

            CodeGenerationTestUtils.DatabaseGenerationTestGenerateAllTables(
                    "System.Data.OracleClient"
                    , "System.Data.OracleClient"
                    , DatabaseType.Oracle
                    , "System.Data.OracleClient.OracleConnection"
                    , _OracleExampleConnectionString
                    ,"ORACLEDEVDAYS"
                    , "Karkas.OracleExample"
                    , @"P:\github\Karkas.Ornek.OracleOrnek.Hr"
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
                , @"P:\denemeler\karkas\ornekler\Karkas.Ornek.SqlServerOrnek"
                , true
                , true
                ,true
                , true
                ,null);

        }


    }
}

