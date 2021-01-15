using System;
using System.Collections.Generic;

#nullable disable

namespace WebCore.DBContextofSQLserver
{
    public partial class Dondatct
    {
        public string Madondat { get; set; }
        public string Mamonan { get; set; }
        public byte? Soluong { get; set; }

        public virtual Dondat MadondatNavigation { get; set; }
        public virtual Monan MamonanNavigation { get; set; }
    }
}
