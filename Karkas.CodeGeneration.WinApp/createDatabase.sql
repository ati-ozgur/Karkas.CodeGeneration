BEGIN TRANSACTION;
drop table if exists DatabaseEntry;
CREATE TABLE IF NOT EXISTS DatabaseEntry(
ConnectionName TEXT primary key 
,ConnectionDatabaseType INTEGER
,AbbrevationsAsString TEXT
,ConnectionString TEXT
,CodeGenerationDirectory TEXT
,CodeGenerationNamespace TEXT
,CreationTime TEXT
,LastAccessTime TEXT
,LastWriteTime TEXT
);

INSERT INTO DatabaseEntry VALUES
(
'Karkas.Ornek'
,1 
,''
,'Integrated Security = SSPI; Persist Security Info=False;Initial Catalog=KARKAS_ORNEK;Data Source=localhost'
,'D:\\projects\\karkas\\Karkas.Ornek'
,'Karkas.Ornek'
,''
,''
,''
);


COMMIT;


