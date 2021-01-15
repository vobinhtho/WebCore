using System;
using System.Collections.Generic;

#nullable disable

namespace WebCore.DBContextofSQLserver
{
    public partial class Dondat
    {
        public Dondat()
        {
            Dondatcts = new HashSet<Dondatct>();
            Hoadons = new HashSet<Hoadon>();
        }

        public string Madondat { get; set; }
        public string Makh { get; set; }
        public string Manv { get; set; }
        public byte[] Thoigiandat { get; set; }
        public string Trangthai { get; set; }

        public virtual Khachhang MakhNavigation { get; set; }
        public virtual Nhanvien ManvNavigation { get; set; }
        public virtual ICollection<Dondatct> Dondatcts { get; set; }
        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
