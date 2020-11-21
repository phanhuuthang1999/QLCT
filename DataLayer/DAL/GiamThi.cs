namespace DataLayer.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiamThi")]
    public partial class GiamThi
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string MaGiamThi { get; set; }

        [StringLength(255)]
        public string HoDem { get; set; }

        [StringLength(255)]
        public string Ten { get; set; }

        public int? GIoiTinh { get; set; }

        [StringLength(255)]
        public string DonViCongTac { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
