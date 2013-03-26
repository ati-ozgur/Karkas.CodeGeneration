BEGIN TRANSACTION;
drop table if exists DatabaseEntry;
CREATE TABLE IF NOT EXISTS DatabaseEntry(
ConnectionName TEXT primary key 
,ConnectionDatabaseType INTEGER
,AbbrevationsAsString TEXT,ConnectionString TEXT
,CodeGenerationDirectory TEXT
,CodeGenerationNamespace TEXT
,CreationTime TEXT
,LastAccessTime TEXT
,LastWriteTime TEXT
);
COMMIT;


