namespace DataLayer.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KT_KyThi
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string MaKyThi { get; set; }

        public int? IDMonHoc { get; set; }

        [StringLength(200)]
        public string TenKyThi { get; set; }

        [StringLength(200)]
        public string DoiTuong { get; set; }

        public int? IDGiamKham { get; set; }

        public DateTime? TGLamBai { get; set; }

        public DateTime? TGMoDe { get; set; }

        public int? TongSoCau { get; set; }
    }
}
