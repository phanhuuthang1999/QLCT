namespace DataLayer.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TestCase")]
    public partial class TestCase
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Input { get; set; }

        [StringLength(255)]
        public string Output { get; set; }

        public virtual CauHoi CauHoi { get; set; }

        public virtual KQ_TC KQ_TC { get; set; }
    }
}
