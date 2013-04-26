
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
			return @"SELECT COUNT(*) FROM DatabaseEntry";
		}
	}
	protected override string SelectString
	{
		get 
		{
			return @"SELECT ConnectionName,ConnectionDatabaseType,ConnectionString,DatabaseNamePhysical,DatabaseNameLogical,ProjectNameSpace,CodeGenerationDirectory,ViewCodeGenerateEtsinMi,StoredProcedureCodeGenerateEtsinMi,SemaIsminiSorgulardaKullan,SemaIsminiDizinlerdeKullan,SysTablolariniAtla,IgnoredSchemaList,AbbrevationsAsString,CreationTime,LastAccessTime,LastWriteTime FROM DatabaseEntry";
		}
	}
	protected override string DeleteString
	{
		get 
		{
			return @"DELETE   FROM DatabaseEntry WHERE ConnectionName = @ConnectionName ";
		}
	}
	protected override string UpdateString
	{
		get 
		{
			return @"UPDATE DatabaseEntry
			 SET 
			ConnectionDatabaseType = @ConnectionDatabaseType,ConnectionString = @ConnectionString,DatabaseNamePhysical = @DatabaseNamePhysical,DatabaseNameLogical = @DatabaseNameLogical,ProjectNameSpace = @ProjectNameSpace,CodeGenerationDirectory = @CodeGenerationDirectory,ViewCodeGenerateEtsinMi = @ViewCodeGenerateEtsinMi,StoredProcedureCodeGenerateEtsinMi = @StoredProcedureCodeGenerateEtsinMi,SemaIsminiSorgulardaKullan = @SemaIsminiSorgulardaKullan,SemaIsminiDizinlerdeKullan = @SemaIsminiDizinlerdeKullan,SysTablolariniAtla = @SysTablolariniAtla,IgnoredSchemaList = @IgnoredSchemaList,AbbrevationsAsString = @AbbrevationsAsString,CreationTime = @CreationTime,LastAccessTime = @LastAccessTime,LastWriteTime = @LastWriteTime			
			WHERE 
			 ConnectionName = @ConnectionName ";
		}
	}
	protected override string InsertString
	{
		get 
		{
			return @"INSERT INTO DatabaseEntry 
			 (ConnectionName,ConnectionDatabaseType,ConnectionString,DatabaseNamePhysical,DatabaseNameLogical,ProjectNameSpace,CodeGenerationDirectory,ViewCodeGenerateEtsinMi,StoredProcedureCodeGenerateEtsinMi,SemaIsminiSorgulardaKullan,SemaIsminiDizinlerdeKullan,SysTablolariniAtla,IgnoredSchemaList,AbbrevationsAsString,CreationTime,LastAccessTime,LastWriteTime) 
			 VALUES 
						(@ConnectionName,@ConnectionDatabaseType,@ConnectionString,@DatabaseNamePhysical,@DatabaseNameLogical,@ProjectNameSpace,@CodeGenerationDirectory,@ViewCodeGenerateEtsinMi,@StoredProcedureCodeGenerateEtsinMi,@SemaIsminiSorgulardaKullan,@SemaIsminiDizinlerdeKullan,@SysTablolariniAtla,@IgnoredSchemaList,@AbbrevationsAsString,@CreationTime,@LastAccessTime,@LastWriteTime)";
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
		row.ConnectionDatabaseType = dr.GetString(1);
		row.ConnectionString = dr.GetString(2);
		if (!dr.IsDBNull(3))
		{
			row.DatabaseNamePhysical = dr.GetString(3);
		}
		if (!dr.IsDBNull(4))
		{
			row.DatabaseNameLogical = dr.GetString(4);
		}
		row.ProjectNameSpace = dr.GetString(5);
		row.CodeGenerationDirectory = dr.GetString(6);
		row.ViewCodeGenerateEtsinMi = dr.GetString(7);
		row.StoredProcedureCodeGenerateEtsinMi = dr.GetString(8);
		row.SemaIsminiSorgulardaKullan = dr.GetString(9);
		row.SemaIsminiDizinlerdeKullan = dr.GetString(10);
		row.SysTablolariniAtla = dr.GetString(11);
		row.IgnoredSchemaList = dr.GetString(12);
		if (!dr.IsDBNull(13))
		{
			row.AbbrevationsAsString = dr.GetString(13);
		}
		if (!dr.IsDBNull(14))
		{
			row.CreationTime = dr.GetString(14);
		}
		if (!dr.IsDBNull(15))
		{
			row.LastAccessTime = dr.GetString(15);
		}
		if (!dr.IsDBNull(16))
		{
			row.LastWriteTime = dr.GetString(16);
		}
	}
	protected override void InsertCommandParametersAdd(DbCommand cmd, DatabaseEntry row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@ConnectionName",DbType.String, row.ConnectionName);
		builder.parameterEkle("@ConnectionDatabaseType",DbType.String, row.ConnectionDatabaseType);
		builder.parameterEkle("@ConnectionString",DbType.String, row.ConnectionString);
		builder.parameterEkle("@DatabaseNamePhysical",DbType.String, row.DatabaseNamePhysical);
		builder.parameterEkle("@DatabaseNameLogical",DbType.String, row.DatabaseNameLogical);
		builder.parameterEkle("@ProjectNameSpace",DbType.String, row.ProjectNameSpace);
		builder.parameterEkle("@CodeGenerationDirectory",DbType.String, row.CodeGenerationDirectory);
		builder.parameterEkle("@ViewCodeGenerateEtsinMi",DbType.String, row.ViewCodeGenerateEtsinMi);
		builder.parameterEkle("@StoredProcedureCodeGenerateEtsinMi",DbType.String, row.StoredProcedureCodeGenerateEtsinMi);
		builder.parameterEkle("@SemaIsminiSorgulardaKullan",DbType.String, row.SemaIsminiSorgulardaKullan);
		builder.parameterEkle("@SemaIsminiDizinlerdeKullan",DbType.String, row.SemaIsminiDizinlerdeKullan);
		builder.parameterEkle("@SysTablolariniAtla",DbType.String, row.SysTablolariniAtla);
		builder.parameterEkle("@IgnoredSchemaList",DbType.String, row.IgnoredSchemaList);
		builder.parameterEkle("@AbbrevationsAsString",DbType.String, row.AbbrevationsAsString);
		builder.parameterEkle("@CreationTime",DbType.String, row.CreationTime);
		builder.parameterEkle("@LastAccessTime",DbType.String, row.LastAccessTime);
		builder.parameterEkle("@LastWriteTime",DbType.String, row.LastWriteTime);
	}
	protected override void UpdateCommandParametersAdd(DbCommand cmd, 	DatabaseEntry	 row)
	{
		ParameterBuilder builder = new ParameterBuilder(cmd);
		builder.parameterEkle("@ConnectionName",DbType.String, row.ConnectionName);
		builder.parameterEkle("@ConnectionDatabaseType",DbType.String, row.ConnectionDatabaseType);
		builder.parameterEkle("@ConnectionString",DbType.String, row.ConnectionString);
		builder.parameterEkle("@DatabaseNamePhysical",DbType.String, row.DatabaseNamePhysical);
		builder.parameterEkle("@DatabaseNameLogical",DbType.String, row.DatabaseNameLogical);
		builder.parameterEkle("@ProjectNameSpace",DbType.String, row.ProjectNameSpace);
		builder.parameterEkle("@CodeGenerationDirectory",DbType.String, row.CodeGenerationDirectory);
		builder.parameterEkle("@ViewCodeGenerateEtsinMi",DbType.String, row.ViewCodeGenerateEtsinMi);
		builder.parameterEkle("@StoredProcedureCodeGenerateEtsinMi",DbType.String, row.StoredProcedureCodeGenerateEtsinMi);
		builder.parameterEkle("@SemaIsminiSorgulardaKullan",DbType.String, row.SemaIsminiSorgulardaKullan);
		builder.parameterEkle("@SemaIsminiDizinlerdeKullan",DbType.String, row.SemaIsminiDizinlerdeKullan);
		builder.parameterEkle("@SysTablolariniAtla",DbType.String, row.SysTablolariniAtla);
		builder.parameterEkle("@IgnoredSchemaList",DbType.String, row.IgnoredSchemaList);
		builder.parameterEkle("@AbbrevationsAsString",DbType.String, row.AbbrevationsAsString);
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
