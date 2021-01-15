using System;
using System.Collections.Generic;

#nullable disable

namespace WebCore.DBContextofSQLserver
{
    public partial class Loaimonan
    {
        public Loaimonan()
        {
            Monans = new HashSet<Monan>();
        }

        public string Maloai { get; set; }
        public string Tenloai { get; set; }

        public virtual ICollection<Monan> Monans { get; set; }
    }
}
