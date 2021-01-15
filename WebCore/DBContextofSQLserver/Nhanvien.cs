using System;
using System.Collections.Generic;

#nullable disable

namespace WebCore.DBContextofSQLserver
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Dondats = new HashSet<Dondat>();
        }

        public string Manv { get; set; }
        public string Matk { get; set; }
        public string Tennv { get; set; }
        public string Sdtnv { get; set; }
        public string Diachinv { get; set; }
        public string Gioitinh { get; set; }
        public DateTime? Ngaysinh { get; set; }

        public virtual Taikhoan MatkNavigation { get; set; }
        public virtual ICollection<Dondat> Dondats { get; set; }
    }
}
