using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.CodeGenerationHelper.Interfaces
{
    public interface ICodeGenerationPersistanceValues
    {
        string Name { get; set; }
        string ProjectNameSpace { get; }
        string ProjectFolder { get; }


        string DatabaseNamePhysical
        {
            get;
        }

        string DatabaseNameLogical
        {
            get;
            set;
        }


        bool SemaIsminiSorgulardaKullan
        {
            get;
            set;
        }

        bool SemaIsminiDizinlerdeKullan
        {
            get;
            set;
        }

        List<DatabaseAbbreviations> ListDatabaseAbbreviations
        {
            get;
            set;
        }

        bool DboSemaTablolariniAtla
        {
            get;
            set;
        }
        bool SysTablolariniAtla
        {
            get;
            set;
        }

    }
}
