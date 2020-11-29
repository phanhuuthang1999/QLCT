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
        /// 1 : New : Phòng kh?i t?o
        /// 2 : Open: Thí sinh ch? ???c phép ??ng nh?p
        /// 3 : Start: Thí ???c phép xem và làm bài thi
        /// 4 : Close: B?t bu?c ?óng, submit bài thi
        /// </summary>
        public int? Status { get; set; }

        public virtual CauHoi CauHoi { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }

        public virtual ThiSinh ThiSinh { get; set; }
    }
}
