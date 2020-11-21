namespace DataLayer.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KQ_TC
    {
        public int Id { get; set; }

        public bool? isTrue { get; set; }

        public virtual KetQua KetQua { get; set; }

        public virtual TestCase TestCase { get; set; }
    }
}
