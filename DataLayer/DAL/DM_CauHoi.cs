namespace DataLayer.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DM_CauHoi
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string MaCH { get; set; }

        public string NoiDung { get; set; }

        [Column(TypeName = "image")]
        public byte[] Hinh { get; set; }

        public int? IDMonHoc { get; set; }

        [StringLength(50)]
        public string IDNgonNgu { get; set; }

        public bool? HinhThuc { get; set; }
    }
}
