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

namespace Karkas.MyGenerationConsoleTest
{
    public class Program
    {
        public const string _SqlServerExampleConnectionString = "Data Source=localhost;Initial Catalog=KARKAS_ORNEK;Integrated Security=True";
        public const string _OracleExampleConnectionString = "Data Source=ORACLEDEVDAYS;Persist Security Info=True;User ID=hr;Password=hr;Unicode=True";
        public const string _SqliteExampleConnectionString = "Data Source=testdb.db";


        public static void Main(string[] args)
        {
            //OracleTest();
            //SqlServerTest();
            //SqliteTest();
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

        private static void SqliteTest()
        {
            DbConnection connection = null;
            AdoTemplate template = new AdoTemplate();
            Assembly oracleAssembly = Assembly.LoadWithPartialName("System.Data.SQLite");
            Object objReflection = Activator.CreateInstance(oracleAssembly.FullName, "System.Data.SQLite.SQLiteConnection");

            if (objReflection != null && objReflection is ObjectHandle)
            {
                ObjectHandle handle = (ObjectHandle)objReflection;

                Object objConnection = handle.Unwrap();
                connection = (DbConnection)objConnection;
                connection.ConnectionString = _SqliteExampleConnectionString;
                connection.Open();
                connection.Close();
                ConnectionSingleton.Instance.ConnectionString = _SqliteExampleConnectionString;
                ConnectionSingleton.Instance.ProviderName = "System.Data.SQLite";
                template = new AdoTemplate();
                template.Connection = connection;
            }
            IDatabaseHelper helper = new SqliteHelper();


            helper.CodeGenerateOneTable(template, _SqliteExampleConnectionString, "Actors", "main", "main", "Karkas.SqliteExample", "P:\\Denemeler\\karkas\\Karkas.SqliteExample", null);


            helper.CodeGenerateAllTables(template, _SqliteExampleConnectionString, "main", "Karkas.SqliteExample", "P:\\Denemeler\\karkas\\Karkas.SqliteExample", true, true, null);
        }

        private static void OracleTest()
        {
            DbConnection connection = null;
            AdoTemplate template = new AdoTemplate();
            Assembly oracleAssembly = Assembly.LoadWithPartialName("System.Data.OracleClient");
            Object objReflection = Activator.CreateInstance(oracleAssembly.FullName, "System.Data.OracleClient.OracleConnection");

            if (objReflection != null && objReflection is ObjectHandle)
            {
                ObjectHandle handle = (ObjectHandle)objReflection;

                Object objConnection = handle.Unwrap();
                connection = (DbConnection)objConnection;
                connection.ConnectionString = _OracleExampleConnectionString;
                connection.Open();
                connection.Close();
                ConnectionSingleton.Instance.ConnectionString = _OracleExampleConnectionString;
                ConnectionSingleton.Instance.ProviderName = "System.Data.OracleClient";
                template = new AdoTemplate();
                template.Connection = connection;
            }
            IDatabaseHelper helper = new OracleHelper();


            helper.CodeGenerateOneTable(template, _OracleExampleConnectionString, "JOB_HISTORY", "HR", "ORACLEDEVDAYS", "Karkas.OracleExample", "D:\\projects\\Examples\\karkas\\Karkas.OracleExample", null);


            helper.CodeGenerateAllTables(template, _OracleExampleConnectionString, "ORACLEDEVDAYS", "Karkas.OracleExample", "D:\\projects\\karkas\\Examples\\Karkas.OracleExample", true, true, null);
        }

        private static void SqlServerTest()
        {
            ConnectionSingleton.Instance.ConnectionString = _SqlServerExampleConnectionString;

            IDatabaseHelper helper = new SqlServerHelper();

            helper.CodeGenerateAllTables(null, _SqlServerExampleConnectionString, "KARKAS_ORNEK", "Karkas.Ornek", "D:\\projects\\karkasTrunk\\Karkas.Ornek", true, true,null);
            helper.CodeGenerateOneTable(null, _SqlServerExampleConnectionString, "ORNEK_TABLO", "ORNEKLER", "KARKAS_ORNEK", "Karkas.Ornek", "D:\\projects\\karkasTrunk\\Karkas.Ornek",null);
        }


    }
}

