namespace DataLayer.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DT_ThiSinh
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(10)]
        public string MaTS { get; set; }

        [StringLength(150)]
        public string HoDem { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [StringLength(200)]
        public string TaiKhoan { get; set; }

        [StringLength(200)]
        public string MatKhau { get; set; }

        public DateTime? NgaySinh { get; set; }

        public int? IDLop { get; set; }

        public int? IDKhoa { get; set; }

        [Column(TypeName = "image")]
        public byte[] HinhAnh { get; set; }

        public bool? TrangThai { get; set; }

        public bool? Quyen { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }

        [NotMapped]
        public string FullName { get { return $"{HoDem} - {Ten}"; } }
    }
}
