namespace DataLayer.DAL
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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
