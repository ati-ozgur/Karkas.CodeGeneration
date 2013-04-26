using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Collections.Generic;
using Karkas.Core.TypeLibrary;
using Karkas.Core.Onaylama;
using Karkas.Core.Onaylama.ForPonos;

namespace Karkas.CodeGeneration.SqliteSupport.TypeLibrary.Main

{
	[Serializable]
	[DebuggerDisplay("ConnectionName = {ConnectionName}")]
	public partial class 	DatabaseEntry: BaseTypeLibrary
	{
		private string connectionName;
		private string connectionDatabaseType;
		private string connectionDbProviderName;
		private string connectionString;
		private string databaseNamePhysical;
		private string databaseNameLogical;
		private string projectNameSpace;
		private string codeGenerationDirectory;
		private string viewCodeGenerate;
		private string storedProcedureCodeGenerate;
		private string useSchemaNameInSqlQueries;
		private string useSchemaNameInFolders;
		private string ignoreSystemTables;
		private string ignoredSchemaList;
		private string abbrevationsAsString;
		private string creationTime;
		private string lastAccessTime;
		private string lastWriteTime;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string ConnectionName
		{
			[DebuggerStepThrough]
			get
			{
				return connectionName;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (connectionName!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				connectionName = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string ConnectionDatabaseType
		{
			[DebuggerStepThrough]
			get
			{
				return connectionDatabaseType;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (connectionDatabaseType!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				connectionDatabaseType = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string ConnectionDbProviderName
		{
			[DebuggerStepThrough]
			get
			{
				return connectionDbProviderName;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (connectionDbProviderName!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				connectionDbProviderName = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string ConnectionString
		{
			[DebuggerStepThrough]
			get
			{
				return connectionString;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (connectionString!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				connectionString = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string DatabaseNamePhysical
		{
			[DebuggerStepThrough]
			get
			{
				return databaseNamePhysical;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (databaseNamePhysical!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				databaseNamePhysical = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string DatabaseNameLogical
		{
			[DebuggerStepThrough]
			get
			{
				return databaseNameLogical;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (databaseNameLogical!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				databaseNameLogical = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string ProjectNameSpace
		{
			[DebuggerStepThrough]
			get
			{
				return projectNameSpace;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (projectNameSpace!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				projectNameSpace = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string CodeGenerationDirectory
		{
			[DebuggerStepThrough]
			get
			{
				return codeGenerationDirectory;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (codeGenerationDirectory!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				codeGenerationDirectory = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string ViewCodeGenerate
		{
			[DebuggerStepThrough]
			get
			{
				return viewCodeGenerate;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (viewCodeGenerate!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				viewCodeGenerate = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string StoredProcedureCodeGenerate
		{
			[DebuggerStepThrough]
			get
			{
				return storedProcedureCodeGenerate;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (storedProcedureCodeGenerate!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				storedProcedureCodeGenerate = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string UseSchemaNameInSqlQueries
		{
			[DebuggerStepThrough]
			get
			{
				return useSchemaNameInSqlQueries;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (useSchemaNameInSqlQueries!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				useSchemaNameInSqlQueries = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string UseSchemaNameInFolders
		{
			[DebuggerStepThrough]
			get
			{
				return useSchemaNameInFolders;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (useSchemaNameInFolders!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				useSchemaNameInFolders = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string IgnoreSystemTables
		{
			[DebuggerStepThrough]
			get
			{
				return ignoreSystemTables;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (ignoreSystemTables!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				ignoreSystemTables = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string IgnoredSchemaList
		{
			[DebuggerStepThrough]
			get
			{
				return ignoredSchemaList;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (ignoredSchemaList!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				ignoredSchemaList = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string AbbrevationsAsString
		{
			[DebuggerStepThrough]
			get
			{
				return abbrevationsAsString;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (abbrevationsAsString!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				abbrevationsAsString = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string CreationTime
		{
			[DebuggerStepThrough]
			get
			{
				return creationTime;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (creationTime!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				creationTime = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string LastAccessTime
		{
			[DebuggerStepThrough]
			get
			{
				return lastAccessTime;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (lastAccessTime!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				lastAccessTime = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string LastWriteTime
		{
			[DebuggerStepThrough]
			get
			{
				return lastWriteTime;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (lastWriteTime!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				lastWriteTime = value;
			}
		}

	public class PropertyIsimleri
	{
		public const string ConnectionName = "ConnectionName";
		public const string ConnectionDatabaseType = "ConnectionDatabaseType";
		public const string ConnectionDbProviderName = "ConnectionDbProviderName";
		public const string ConnectionString = "ConnectionString";
		public const string DatabaseNamePhysical = "DatabaseNamePhysical";
		public const string DatabaseNameLogical = "DatabaseNameLogical";
		public const string ProjectNameSpace = "ProjectNameSpace";
		public const string CodeGenerationDirectory = "CodeGenerationDirectory";
		public const string ViewCodeGenerate = "ViewCodeGenerate";
		public const string StoredProcedureCodeGenerate = "StoredProcedureCodeGenerate";
		public const string UseSchemaNameInSqlQueries = "UseSchemaNameInSqlQueries";
		public const string UseSchemaNameInFolders = "UseSchemaNameInFolders";
		public const string IgnoreSystemTables = "IgnoreSystemTables";
		public const string IgnoredSchemaList = "IgnoredSchemaList";
		public const string AbbrevationsAsString = "AbbrevationsAsString";
		public const string CreationTime = "CreationTime";
		public const string LastAccessTime = "LastAccessTime";
		public const string LastWriteTime = "LastWriteTime";
	}
		public DatabaseEntry ShallowCopy()
		{
			DatabaseEntry obj = new DatabaseEntry();
			obj.connectionName = connectionName;
			obj.connectionDatabaseType = connectionDatabaseType;
			obj.connectionDbProviderName = connectionDbProviderName;
			obj.connectionString = connectionString;
			obj.databaseNamePhysical = databaseNamePhysical;
			obj.databaseNameLogical = databaseNameLogical;
			obj.projectNameSpace = projectNameSpace;
			obj.codeGenerationDirectory = codeGenerationDirectory;
			obj.viewCodeGenerate = viewCodeGenerate;
			obj.storedProcedureCodeGenerate = storedProcedureCodeGenerate;
			obj.useSchemaNameInSqlQueries = useSchemaNameInSqlQueries;
			obj.useSchemaNameInFolders = useSchemaNameInFolders;
			obj.ignoreSystemTables = ignoreSystemTables;
			obj.ignoredSchemaList = ignoredSchemaList;
			obj.abbrevationsAsString = abbrevationsAsString;
			obj.creationTime = creationTime;
			obj.lastAccessTime = lastAccessTime;
			obj.lastWriteTime = lastWriteTime;
			return obj;
		}
	

	protected override void OnaylamaListesiniOlusturCodeGeneration()
	{
		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "ConnectionDatabaseType"));		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "ConnectionDbProviderName"));		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "ConnectionString"));		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "ProjectNameSpace"));		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "CodeGenerationDirectory"));		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "ViewCodeGenerate"));		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "StoredProcedureCodeGenerate"));		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "UseSchemaNameInSqlQueries"));		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "UseSchemaNameInFolders"));		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "IgnoreSystemTables"));		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "IgnoredSchemaList"));	}
	public static class EtiketIsimleri
	{
		const string namespaceVeClass = "Karkas.CodeGeneration.SqliteSupport.TypeLibrary.Main";
		public static string ConnectionName
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".ConnectionName"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "ConnectionName";
				}
			}
		}
		public static string ConnectionDatabaseType
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".ConnectionDatabaseType"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "ConnectionDatabaseType";
				}
			}
		}
		public static string ConnectionDbProviderName
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".ConnectionDbProviderName"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "ConnectionDbProviderName";
				}
			}
		}
		public static string ConnectionString
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".ConnectionString"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "ConnectionString";
				}
			}
		}
		public static string DatabaseNamePhysical
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".DatabaseNamePhysical"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "DatabaseNamePhysical";
				}
			}
		}
		public static string DatabaseNameLogical
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".DatabaseNameLogical"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "DatabaseNameLogical";
				}
			}
		}
		public static string ProjectNameSpace
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".ProjectNameSpace"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "ProjectNameSpace";
				}
			}
		}
		public static string CodeGenerationDirectory
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".CodeGenerationDirectory"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "CodeGenerationDirectory";
				}
			}
		}
		public static string ViewCodeGenerate
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".ViewCodeGenerate"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "ViewCodeGenerate";
				}
			}
		}
		public static string StoredProcedureCodeGenerate
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".StoredProcedureCodeGenerate"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "StoredProcedureCodeGenerate";
				}
			}
		}
		public static string UseSchemaNameInSqlQueries
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".UseSchemaNameInSqlQueries"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "UseSchemaNameInSqlQueries";
				}
			}
		}
		public static string UseSchemaNameInFolders
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".UseSchemaNameInFolders"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "UseSchemaNameInFolders";
				}
			}
		}
		public static string IgnoreSystemTables
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".IgnoreSystemTables"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "IgnoreSystemTables";
				}
			}
		}
		public static string IgnoredSchemaList
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".IgnoredSchemaList"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "IgnoredSchemaList";
				}
			}
		}
		public static string AbbrevationsAsString
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".AbbrevationsAsString"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "AbbrevationsAsString";
				}
			}
		}
		public static string CreationTime
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".CreationTime"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "CreationTime";
				}
			}
		}
		public static string LastAccessTime
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".LastAccessTime"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "LastAccessTime";
				}
			}
		}
		public static string LastWriteTime
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".LastWriteTime"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "LastWriteTime";
				}
			}
		}
	}
}
}
