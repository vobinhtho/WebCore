using System;
using System.Collections.Generic;

#nullable disable

namespace WebCore.DBContextofSQLserver
{
    public partial class Voucher
    {
        public Voucher()
        {
            Hoadons = new HashSet<Hoadon>();
        }

        public int IdVoucher { get; set; }
        public string Mavoucher { get; set; }
        public string Tenvoucher { get; set; }
        public int? Tylegiamgia { get; set; }

        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
