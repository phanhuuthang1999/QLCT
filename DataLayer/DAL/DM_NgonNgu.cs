namespace DataLayer.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DM_NgonNgu
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string MaNN { get; set; }

        [StringLength(100)]
        public string TenNN { get; set; }
    }
}
