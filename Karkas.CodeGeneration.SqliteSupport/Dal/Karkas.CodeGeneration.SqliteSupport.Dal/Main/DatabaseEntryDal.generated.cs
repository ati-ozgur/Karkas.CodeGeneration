
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Karkas.Core.DataUtil;
using Karkas.CodeGeneration.SqliteSupport.TypeLibrary;
using Karkas.CodeGeneration.SqliteSupport.TypeLibrary.Main;


namespace Karkas.CodeGeneration.SqliteSupport.Dal.Main
{
public partial class DatabaseEntryDal : BaseDal<DatabaseEntry>
{
	
	public override string DatabaseName
	{
		get
		{
			return "main";
		}
	}
	protected override void identityKolonDegeriniSetle(DatabaseEntry pTypeLibrary,long pIdentityKolonValue)
	{
	}
	protected override string SelectCountString
	{
		get
		{
			return @"SELECT COUNT(*) FROM main.DatabaseEntry";
		}
	}
	protected override string SelectString
	{
		get 
		{
			return @"SELECT ConnectionName,ConnectionDatabaseType,AbbrevationsAsString,ConnectionString,CodeGenerationDirectory,CodeGenerationNamespace,CreationTime,LastAccessTime,LastWriteTime FROM main.DatabaseEntry";
		}
	}
	protected override string DeleteString
	{
		get 
		{
			return @"DELETE   FROM main.DatabaseEntry WHERE ConnectionName = @ConnectionName";
		}
	}
	protected override string UpdateString
	{
		get 
		{
			return @"UPDATE main.DatabaseEntry
			 SET 
			ConnectionDatabaseType = @ConnectionDatabaseType,AbbrevationsAsString = @AbbrevationsAsString,ConnectionString = @ConnectionString,CodeGenerationDirectory = @CodeGenerationDirectory,CodeGenerationNamespace = @CodeGenerationNamespace,CreationTime = @CreationTime,LastAccessTime = @LastAccessTime,LastWriteTime = @LastWriteTime			
			WHERE 
			 ConnectionName = @ConnectionName ";
		}
	}
	protected override string InsertString
	{
		get 
		{
			return @"INSERT INTO main.DatabaseEntry 
			 (ConnectionName,ConnectionDatabaseType,AbbrevationsAsString,ConnectionString,CodeGenerationDirectory,CodeGenerationNamespace,CreationTime,LastAccessTime,LastWriteTime) 
			 VALUES 
						(@ConnectionName,@ConnectionDatabaseType,@AbbrevationsAsString,@ConnectionString,@CodeGenerationDirectory,@CodeGenerationNamespace,@CreationTime,@LastAccessTime,@LastWriteTime)";
		}
	}
	public DatabaseEntry SorgulaConnectionNameIle(string p1)
	{
		List<DatabaseEntry> liste = new List<DatabaseEntry>();
		SorguCalistir(liste,String.Format(" ConnectionName = '{0}'", p1));		
		if (liste.Count > 0)
		{
			return liste[0];
		}
		else
		{
			return null;
		}
	}
	
	protected override bool IdentityVarMi
	{
		get
		{
			return false;
		}
	}
	
	protected override bool PkGuidMi
	{
		get
		{
			return false;
		}
	}
	
	
	public override string PrimaryKey
	{
		get
		{
			return "ConnectionName";
		}
	}
	
	public virtual void Sil(string ConnectionName)
	{
		DatabaseEntry row = new DatabaseEntry();
		row.ConnectionName = ConnectionName;
		base.Sil(row);
	}
	protected override void ProcessRow(IDataReader dr, DatabaseEntry row)
	{
		row.ConnectionName = dr.GetString(0);
		row.ConnectionDatabaseType = dr.GetInt64(1);
		row.AbbrevationsAsString = dr.GetString(2);
		row.ConnectionString = dr.GetString(3);
		row.CodeGenerationDirectory = dr.GetString(4);
		row.CodeGenerationNamespace = dr.GetString(5);
		row.CreationTime = dr.GetString(6);
		row.LastAccessTime = dr.GetString(7);
		row.LastWriteTime = dr.GetString(8);
	}
	protected override void InsertCommandParametersAdd(DbCommand cmd, DatabaseEntry row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@ConnectionName",DbType.String, row.ConnectionName);
		builder.parameterEkle("@ConnectionDatabaseType",DbType.Int64, row.ConnectionDatabaseType);
		builder.parameterEkle("@AbbrevationsAsString",DbType.String, row.AbbrevationsAsString);
		builder.parameterEkle("@ConnectionString",DbType.String, row.ConnectionString);
		builder.parameterEkle("@CodeGenerationDirectory",DbType.String, row.CodeGenerationDirectory);
		builder.parameterEkle("@CodeGenerationNamespace",DbType.String, row.CodeGenerationNamespace);
		builder.parameterEkle("@CreationTime",DbType.String, row.CreationTime);
		builder.parameterEkle("@LastAccessTime",DbType.String, row.LastAccessTime);
		builder.parameterEkle("@LastWriteTime",DbType.String, row.LastWriteTime);
	}
	protected override void UpdateCommandParametersAdd(DbCommand cmd, 	DatabaseEntry	 row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@ConnectionName",DbType.String, row.ConnectionName);
		builder.parameterEkle("@ConnectionDatabaseType",DbType.Int64, row.ConnectionDatabaseType);
		builder.parameterEkle("@AbbrevationsAsString",DbType.String, row.AbbrevationsAsString);
		builder.parameterEkle("@ConnectionString",DbType.String, row.ConnectionString);
		builder.parameterEkle("@CodeGenerationDirectory",DbType.String, row.CodeGenerationDirectory);
		builder.parameterEkle("@CodeGenerationNamespace",DbType.String, row.CodeGenerationNamespace);
		builder.parameterEkle("@CreationTime",DbType.String, row.CreationTime);
		builder.parameterEkle("@LastAccessTime",DbType.String, row.LastAccessTime);
		builder.parameterEkle("@LastWriteTime",DbType.String, row.LastWriteTime);
	}
	protected override void DeleteCommandParametersAdd(DbCommand cmd, 	DatabaseEntry	 row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@ConnectionName",DbType.String, row.ConnectionName);
	}
}
}
