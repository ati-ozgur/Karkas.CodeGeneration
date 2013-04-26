PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE DatabaseEntry(
ConnectionName TEXT primary key
,ConnectionDatabaseType TEXT NOT NULL
,ConnectionString TEXT NOT NULL
,DatabaseNameLogical TEXT
,UseSchemaInSQL TEXT
,CodeGenerationDirectory TEXT NOT NULL
,CodeGenerationNamespace TEXT NOT NULL
,AbbrevationsAsString TEXT
,CreationTime TEXT
,LastAccessTime TEXT
,LastWriteTime TEXT
);
INSERT INTO DatabaseEntry VALUES('Karkas.Ornek','SqlServer','Integrated Security = SSPI; Persist Security Info=False;Initial Catalog=KARKAS_ORNEK;Data Source=localhost\SQLSERVER2012',NULL,NULL,'D:\projects\karkas\Karkas.Ornek','Karkas.Ornek',NULL,'2013-04-DD 12:28:22','2013-04-25 12:28:22','2013-04-25 12:28:22');
INSERT INTO DatabaseEntry VALUES('sqlite_connections','Sqlite','Data Source=connectionsDb.db',NULL,NULL,'P:\denemeler\karkas\Karkas.SqliteExample','Karkas.SqliteExample',NULL,'2013-04-DD 12:28:15','2013-04-25 12:28:15','2013-04-25 12:28:15');
INSERT INTO DatabaseEntry VALUES('AYDIN','Oracle','Data Source=ORACLEDEVDAYS;Persist Security Info=True;User ID=AYDIN;Password=123;Unicode=True',NULL,NULL,'P:\denemeler\AYDIN\Halkleasing','Halkleasing',NULL,'2013-04-DD 12:29:57','2013-04-25 12:29:57','2013-04-25 12:29:57');
COMMIT;
