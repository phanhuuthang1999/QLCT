namespace DataLayer.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhongThi")]
    public partial class PhongThi
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string MaPhong { get; set; }

        [StringLength(255)]
        public string TenPhong { get; set; }

        public int? IDGiamThi { get; set; }

        public int? Port { get; set; }

        public int? Status { get; set; }

        public TimeSpan? ThoiGianKetThuc { get; set; }

        public virtual CauHoi CauHoi { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }

        public virtual ThiSinh ThiSinh { get; set; }
    }
}
