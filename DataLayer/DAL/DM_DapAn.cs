namespace DataLayer.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DM_DapAn
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string MaDA { get; set; }

        public int? IDCauHoi { get; set; }

        public string NoiDung { get; set; }

        public bool? IsTrue { get; set; }
    }
}
