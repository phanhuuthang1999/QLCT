using DataLayer.BLL;
using ProxyObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCT_Server
{
    public partial class frmServer : Form
    {
        #region Variable

        private TcpChannel tcpChannel = null;
#pragma warning disable CS0169 // The field 'frmServer.type' is never used
        private Type type;
#pragma warning restore CS0169 // The field 'frmServer.type' is never used
#pragma warning disable CS0169 // The field 'frmServer.wellKnowMode' is never used
        private WellKnownObjectMode wellKnowMode;
#pragma warning restore CS0169 // The field 'frmServer.wellKnowMode' is never used
        private PrimeProxy primeProxy;

        private SitesBll _bus;
        #endregion

        #region Constructor

        public frmServer()
        {
            InitializeComponent();

            _bus = new SitesBll();

            btnStart.Click += BtnStart_Click;
            btnDongConnect.Click += BtnDongConnect_Click;
            btnAddNewSite.Click += BtnAddNewSite_Click;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            btnSearch.Click += BtnSearch_Click;
            btnEnd.Click += BtnEnd_Click;

        }

        #endregion

        #region Protected

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            lblTitle.Text = Instance.TitleServer;

        }

        #endregion

        #region Private

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            dgvSites.DataSource = _bus.GetAllSites(txtSearch.Text);
        }

        private void BtnEnd_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Events

        private void BtnStart_Click(object sender, EventArgs e)
        {
            primeProxy = new PrimeProxy();

            try
            {
                tcpChannel = TwoWaysServerTerminal.StartListening(Instance.Port, Instance.TcpChannelName, primeProxy, Instance.objURI);
                UICommon.ShowMsgInfoString("Mở cổng thành công");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDongConnect_Click(object sender, EventArgs e)
        {
            /*try
            //{
            //    primeProxy.EndChannel();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(""+ex);
            }*/
            Environment.Exit(1);
            Application.ExitThread();
        }

        private void BtnAddNewSite_Click(object sender, EventArgs e)
        {
            frmAddSite frm = new frmAddSite();
            if (frm.ShowDialog()==DialogResult.OK)
            {
                btnSearch.PerformClick();
            }
        }

        #endregion

    }
}
