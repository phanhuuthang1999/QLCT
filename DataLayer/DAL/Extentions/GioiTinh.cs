using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL.Extentions
{
    [NotMapped]
    public partial class GioiTinh
    {
        public int Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }

    }
}
