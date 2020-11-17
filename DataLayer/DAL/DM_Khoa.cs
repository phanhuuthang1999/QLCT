namespace DataLayer.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DM_Khoa
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string MaKhoa { get; set; }

        [StringLength(200)]
        public string TenKhoa { get; set; }
    }
}
