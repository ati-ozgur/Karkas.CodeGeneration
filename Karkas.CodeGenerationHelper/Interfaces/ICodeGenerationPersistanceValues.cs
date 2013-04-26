using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.CodeGenerationHelper.Interfaces
{
    public interface ICodeGenerationPersistanceValues
    {
        string ConnectionName { get; set; }
        string ConnectionDatabaseType { get; set; }
        
        string ConnectionString { get; set; }
        string DatabaseNamePhysical { get; set; }
        string DatabaseNameLogical { get; set; }
        string ProjectNameSpace { get; set; }
        string CodeGenerationDirectory { get; set; }

        //bool ViewCodeGenerateEtsinMi { get; set; }
        //bool StoredProcedureCodeGenerateEtsinMi { get; set; }
        bool SemaIsminiSorgulardaKullan { get; set; }
        bool SemaIsminiDizinlerdeKullan { get; set; }
        bool DboSemaTablolariniAtla { get; set; }
        bool SysTablolariniAtla { get; set; }

        List<DatabaseAbbreviations> ListDatabaseAbbreviations { get; set; }


    }
}
