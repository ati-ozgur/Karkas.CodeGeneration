BEGIN TRANSACTION;
CREATE TABLE DatabaseEntry(
ConnectionName TEXT primary key
,ConnectionDatabaseType TEXT NOT NULL
,ConnectionString TEXT NOT NULL
,DatabaseNamePhysical TEXT
,DatabaseNameLogical TEXT
,ProjectNameSpace TEXT NOT NULL
,CodeGenerationDirectory TEXT NOT NULL
,ViewCodeGenerateEtsinMi TEXT NOT NULL
,StoredProcedureCodeGenerateEtsinMi TEXT NOT NULL
,SemaIsminiSorgulardaKullan TEXT NOT NULL
,SemaIsminiDizinlerdeKullan TEXT NOT NULL
,DboSemaTablolariniAtla TEXT NOT NULL
,SysTablolariniAtla TEXT NOT NULL
,AbbrevationsAsString TEXT
,CreationTime TEXT
,LastAccessTime TEXT
,LastWriteTime TEXT
);

INSERT INTO DatabaseEntry VALUES('Karkas.Ornek'
	,'SqlServer'
	,'Integrated Security = SSPI; Persist Security Info=False;Initial Catalog=KARKAS_ORNEK;Data Source=localhost\SQLSERVER2012'
	,'KARKAS_ORNEK'
	,'KARKAS_ORNEK'
	,'Karkas.Ornek'
	,'P:\denemeler\karkas\ornekler\Karkas.Ornek.SqlServer'
	,'false'
	,'false'
	,'true' 
	,'true' 
	,'true' 
	,'true' 
	, ''
	,'2013-04-DD 12:28:22'
	,'2013-04-25 12:28:22'
	,'2013-04-25 12:28:22');

INSERT INTO DatabaseEntry VALUES('karkas.sqlite.persistence'
	,'Sqlite'
	,'Data Source=connectionsDb.db'
	,'main'
	,'karkas.sqlite.persistence'
	,'Karkas.Ornek'
	,'P:\denemeler\karkas\ornekler\Karkas.Ornek.Sqlite'
	,'false'
	,'false'
	,'false' 
	,'false' 
	,'true' 
	,'true' 
	, ''
	,'2013-04-DD 12:28:22'
	,'2013-04-25 12:28:22'
	,'2013-04-25 12:28:22');
 INSERT INTO DatabaseEntry VALUES('','',NULL,NULL,'P:\denemeler\karkas\Karkas.SqliteExample','Karkas.SqliteExample',NULL,'2013-04-DD 12:28:15','2013-04-25 12:28:15','2013-04-25 12:28:15');
-- INSERT INTO DatabaseEntry VALUES('AYDIN','Oracle','Data Source=ORACLEDEVDAYS;Persist Security Info=True;User ID=AYDIN;Password=123;Unicode=True',NULL,NULL,'P:\denemeler\AYDIN\Halkleasing','Halkleasing',NULL,'2013-04-DD 12:29:57','2013-04-25 12:29:57','2013-04-25 12:29:57');
COMMIT;
