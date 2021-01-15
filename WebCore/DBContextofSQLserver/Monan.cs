using System;
using System.Collections.Generic;

#nullable disable

namespace WebCore.DBContextofSQLserver
{
    public partial class Monan
    {
        public Monan()
        {
            Dondatcts = new HashSet<Dondatct>();
            Hoadons = new HashSet<Hoadon>();
        }

        public string Mamonan { get; set; }
        public string Manhom { get; set; }
        public string Maloai { get; set; }
        public string Tenmonan { get; set; }
        public string Mieuta { get; set; }
        public int? Giaban { get; set; }
        public int? Giagiam { get; set; }
        public string Hinh { get; set; }

        public virtual Loaimonan MaloaiNavigation { get; set; }
        public virtual Nhommonan ManhomNavigation { get; set; }
        public virtual ICollection<Dondatct> Dondatcts { get; set; }
        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
