using System;
using System.Collections.Generic;

#nullable disable

namespace WebCore.DBContextofSQLserver
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Dondats = new HashSet<Dondat>();
        }

        public string Makh { get; set; }
        public string Matk { get; set; }
        public string Tenkh { get; set; }
        public string Sdtkh { get; set; }
        public string Diachikh { get; set; }

        public virtual Taikhoan MatkNavigation { get; set; }
        public virtual ICollection<Dondat> Dondats { get; set; }
    }
}
