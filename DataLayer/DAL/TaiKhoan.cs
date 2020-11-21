namespace DataLayer.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(255)]
        public string Tk { get; set; }

        [StringLength(255)]
        public string MatKhau { get; set; }

        public bool? isQuyen { get; set; }

        public bool? isActive { get; set; }

        public virtual GiamThi GiamThi { get; set; }

        public virtual KetQua KetQua { get; set; }

        public virtual PhongThi PhongThi { get; set; }

        public virtual ThiSinh ThiSinh { get; set; }
    }
}
