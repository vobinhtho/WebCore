using System;
using System.Collections.Generic;

#nullable disable

namespace WebCore.DBContextofSQLserver
{
    public partial class Taikhoan
    {
        public Taikhoan()
        {
            Khachhangs = new HashSet<Khachhang>();
            Nhanviens = new HashSet<Nhanvien>();
        }

        public string Matk { get; set; }
        public string Password { get; set; }
        public string Quyensd { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Khachhang> Khachhangs { get; set; }
        public virtual ICollection<Nhanvien> Nhanviens { get; set; }
    }
}
