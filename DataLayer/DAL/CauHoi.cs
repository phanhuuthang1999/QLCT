namespace DataLayer.DAL
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CauHoi")]
    public partial class CauHoi
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string MaCauHoi { get; set; }

        [StringLength(255)]
        public string TenCauHoi { get; set; }

        [StringLength(255)]
        public string NoiDung { get; set; }

        [StringLength(255)]
        public string HinhAnh { get; set; }

        public bool? isSuDung { get; set; }

        public virtual TestCase TestCase { get; set; }

        public virtual KetQua KetQua { get; set; }

        public virtual PhongThi PhongThi { get; set; }
    }
}
