namespace DataLayer.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DM_KetQua
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string MaKQ { get; set; }

        public int? IDThiSinh { get; set; }

        public int? IDKyThi { get; set; }

        public DateTime? NgayThi { get; set; }

        public int? Diem { get; set; }

        public int? TongTGThi { get; set; }
    }
}
