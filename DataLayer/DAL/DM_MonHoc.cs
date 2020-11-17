namespace DataLayer.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DM_MonHoc
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string MaMon { get; set; }

        [StringLength(200)]
        public string TenMon { get; set; }
    }
}
