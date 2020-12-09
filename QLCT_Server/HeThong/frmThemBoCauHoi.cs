using DataLayer.BLL;
using DataLayer.DAL;
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

namespace QLCT_Server.HeThong
{
    public partial class frmThemBoCauHoi : Form
    {

        #region Variable

        CauHoiBll _bus;

        #endregion

        #region Constructor

        public frmThemBoCauHoi()
        {
            InitializeComponent();
            _bus = new CauHoiBll();

            btnExit.Click += BtnExit_Click;
            btnSave.Click += BtnSave_Click;
        }

        #endregion

        #region Protected

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (CauHoi != null)
            {
                if (CauHoi.Id == 0)
                {
                    this.Text = Instance.TitleCoppyCauHoi;
                }
                this.Text = Instance.TitleEditCauHoi;
            }
            this.Text = Instance.TitleAddCauHoi;
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

        #region Public

        public CauHoi CauHoi { get; set; }

        #endregion
    }
}
