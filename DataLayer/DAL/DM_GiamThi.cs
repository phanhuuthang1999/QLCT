namespace DataLayer.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DM_GiamThi
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string MaGT { get; set; }

        [StringLength(200)]
        public string TenGT { get; set; }

        [StringLength(200)]
        public string TaiKhoan { get; set; }

        [StringLength(200)]
        public string MatKhau { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(200)]
        public string DonViCongTac { get; set; }

        public bool? Quyen { get; set; }

        public bool? PhanQuyen { get; set; }

        [Column(TypeName = "image")]
        public byte[] HinhAnh { get; set; }
    }
}
