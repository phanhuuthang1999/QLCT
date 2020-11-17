using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Common
{
    public class StructEnum
    {
        public enum EN_GioiTinh
        {
            [Description("Nam")]
            Nam = 1,
            [Description("Nữ")]
            Nu = 0
        }
    }
}
