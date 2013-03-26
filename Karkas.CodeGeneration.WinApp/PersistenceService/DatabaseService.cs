using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.CodeGeneration.WinApp.PersistenceService
{
    public class DatabaseService
    {
        public static List<DatabaseEntry> getAllDatabaseEntriesSortedByName()
        {
            return null;
        }

        public static DatabaseEntry getLastAccessedDatabaseEntry()
        {
            return null;
        }

        private static DatabaseEntry getExampleDatabaseEntry()
        {
            DatabaseEntry de = new DatabaseEntry();
            de.CodeGenerationDirectory = "D:\\projects\\karkas\\Karkas.Ornek";
            de.CodeGenerationNamespace = "Karkas.Ornek";
            de.ConnectionDatabaseType = DatabaseType.SqlServer;
            de.ConnectionName = "KARKAS_ORNEK";
            de.ConnectionString = "Integrated Security = SSPI; Persist Security Info=False;Initial Catalog=KARKAS_ORNEK;Data Source=localhost";
            de.CreationTimeUtc = DateTime.UtcNow;
            de.LastWriteTimeUtc = DateTime.UtcNow;
            de.LastAccessTimeUtc = DateTime.UtcNow;
            return de;
        }




        internal static void deleteDatabase(DatabaseEntry SelectedDatabaseEntry)
        {
            throw new NotImplementedException();
        }

        internal static void Ekle(DatabaseEntry currentDatabaseEntry)
        {
            throw new NotImplementedException();
        }

        internal static void Guncelle(DatabaseEntry databaseEntry)
        {
            throw new NotImplementedException();
        }
    }
}
