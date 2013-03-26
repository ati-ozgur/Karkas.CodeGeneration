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
using Karkas.CodeGenerationHelper;

namespace Karkas.CodeGeneration.SqliteSupport.TypeLibrary.Main
{
    public partial class DatabaseEntry
    {
        public void AddAbbreviations(DatabaseAbbreviations abbr)
        {
            AbbrevationsAsString += abbr.ToString();
        }

        public List<DatabaseAbbreviations> getAbbreviationsDataSource()
        {

            List<DatabaseAbbreviations> list = new List<DatabaseAbbreviations>();
            if (string.IsNullOrEmpty(AbbrevationsAsString))
            {
                return list;
            }
            String[] abbrStringList = AbbrevationsAsString.Split('\n');
            foreach (string item in abbrStringList)
            {
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }
                String[] abbrArrr = item.Split('-');
                DatabaseAbbreviations abbr = new DatabaseAbbreviations();
                abbr.Abbravetion = abbrArrr[0];
                abbr.FullNameReplacement = abbrArrr[1];
                list.Add(abbr);

            }
            return list;
        }

        public override string ToString()
        {
            String str = string.Format("{0}\t{1}\t{2}\t{3}", ConnectionName, ConnectionDatabaseType, CodeGenerationNamespace, ConnectionString);
            return str;

        }


    }
}
