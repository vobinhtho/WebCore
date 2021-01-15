using System;
using System.Collections.Generic;

#nullable disable

namespace WebCore.DBContextofSQLserver
{
    public partial class Hoadon
    {
        public string Mahd { get; set; }
        public string Mamonan { get; set; }
        public string Madondat { get; set; }
        public int IdVoucher { get; set; }
        public int? Tonghd { get; set; }

        public virtual Voucher IdVoucherNavigation { get; set; }
        public virtual Dondat MadondatNavigation { get; set; }
        public virtual Monan MamonanNavigation { get; set; }
    }
}
