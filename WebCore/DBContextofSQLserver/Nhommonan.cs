using System;
using System.Collections.Generic;

#nullable disable

namespace WebCore.DBContextofSQLserver
{
    public partial class Nhommonan
    {
        public Nhommonan()
        {
            Monans = new HashSet<Monan>();
        }

        public string Manhom { get; set; }
        public string Tennhom { get; set; }

        public virtual ICollection<Monan> Monans { get; set; }
    }
}
