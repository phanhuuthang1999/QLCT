using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public class DangNhap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string TenHienThi { get; set; }

        [MaxLength(100)]
        public string TenDN { get; set; }

        [MaxLength(100)]
        public string MatKhau { get; set; }

        public bool TrangThai { get; set; } = true; // True : Đang hoạt động || khóa

        public bool Quyen { get; set; } = false;
    }
}
