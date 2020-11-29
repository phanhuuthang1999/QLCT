using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCT_Server.Controls
{
    public class GridMappingData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HeaderText { get; set; }
        public Type TypeColumn { get; set; }
        public DataGridViewContentAlignment Align { get; set; }

        private bool _isReadOnly = true;
        public bool IsReadOnly { get { return _isReadOnly; } set { _isReadOnly = value; } }
        public bool IsNotViSible { get; set; }
    }
}
