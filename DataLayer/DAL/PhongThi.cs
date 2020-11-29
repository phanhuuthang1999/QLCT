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

        public int? Port { get; set; }

        /// <summary>
        /// 1 : New : Ph�ng kh?i t?o
        /// 2 : Open: Th� sinh ch? ???c ph�p ??ng nh?p
        /// 3 : Start: Th� ???c ph�p xem v� l�m b�i thi
        /// 4 : Close: B?t bu?c ?�ng, submit b�i thi
        /// </summary>
        public int? Status { get; set; }

        public virtual CauHoi CauHoi { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }

        public virtual ThiSinh ThiSinh { get; set; }
    }
}
