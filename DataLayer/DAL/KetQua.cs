namespace DataLayer.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KetQua")]
    public partial class KetQua
    {
        public int Id { get; set; }

        public int? Diem { get; set; }

        public DateTime? NgayThi { get; set; }

        public virtual CauHoi CauHoi { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }

        public virtual KQ_TC KQ_TC { get; set; }
    }
}
