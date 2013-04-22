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
        private String connectionDatabaseType;
		private string abbrevationsAsString;
		private string connectionString;
		private string codeGenerationDirectory;
		private string codeGenerationNamespace;
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
		public String ConnectionDatabaseType
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
		public string CodeGenerationNamespace
		{
			[DebuggerStepThrough]
			get
			{
				return codeGenerationNamespace;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (codeGenerationNamespace!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				codeGenerationNamespace = value;
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

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string ConnectionDatabaseTypeAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return connectionDatabaseType != null ? connectionDatabaseType.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				ConnectionDatabaseType = value;
			}
		}

	public class PropertyIsimleri
	{
		public const string ConnectionName = "ConnectionName";
		public const string ConnectionDatabaseType = "ConnectionDatabaseType";
		public const string AbbrevationsAsString = "AbbrevationsAsString";
		public const string ConnectionString = "ConnectionString";
		public const string CodeGenerationDirectory = "CodeGenerationDirectory";
		public const string CodeGenerationNamespace = "CodeGenerationNamespace";
		public const string CreationTime = "CreationTime";
		public const string LastAccessTime = "LastAccessTime";
		public const string LastWriteTime = "LastWriteTime";
	}
		public DatabaseEntry ShallowCopy()
		{
			DatabaseEntry obj = new DatabaseEntry();
			obj.connectionName = connectionName;
			obj.connectionDatabaseType = connectionDatabaseType;
			obj.abbrevationsAsString = abbrevationsAsString;
			obj.connectionString = connectionString;
			obj.codeGenerationDirectory = codeGenerationDirectory;
			obj.codeGenerationNamespace = codeGenerationNamespace;
			obj.creationTime = creationTime;
			obj.lastAccessTime = lastAccessTime;
			obj.lastWriteTime = lastWriteTime;
			return obj;
		}
	

	protected override void OnaylamaListesiniOlusturCodeGeneration()
	{
	}
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
		public static string CodeGenerationNamespace
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".CodeGenerationNamespace"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "CodeGenerationNamespace";
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
