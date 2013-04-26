using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper;
using NUnit.Framework;
namespace Karkas.CodeGeneration.ConsoleTest
{
	[TestFixture]
	public class SchemaTest
	{
		private static string ConnectionString;
		static SchemaTest()
		{
			ConnectionString = Program._SqlServerExampleConnectionString;
		}


	}
}
