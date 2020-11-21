namespace DataLayer.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThiSinh")]
    public partial class ThiSinh
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? MSSV { get; set; }

        [StringLength(255)]
        public string HoDem { get; set; }

        [StringLength(255)]
        public string Ten { get; set; }

        public DateTime? NgaySinh { get; set; }

        public virtual PhongThi PhongThi { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
