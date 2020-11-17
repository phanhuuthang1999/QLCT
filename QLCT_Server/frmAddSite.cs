using ProxyObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCT_Server
{
    public partial class frmAddSite : Form
    {
        #region Variable

        #endregion

        #region Constructor

        public frmAddSite()
        {
            InitializeComponent();
            btnExit.Click += BtnExit_Click;
            btnSave.Click += BtnSave_Click;
        }

        #endregion

        #region Protected

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Text = Instance.NewSite;
        }

        #endregion

        #region Events

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
