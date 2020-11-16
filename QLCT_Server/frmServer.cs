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
        private Type type;
        private WellKnownObjectMode wellKnowMode;
        private PrimeProxy primeProxy;

        #endregion

        #region Constructor

        public frmServer()
        {
            InitializeComponent();
            btnStart.Click += BtnStart_Click;
            btnColor.Click += BtnColor_Click;
            btnDongConnect.Click += BtnDongConnect_Click;
        }

        #endregion

        #region Events

        private void BtnStart_Click(object sender, EventArgs e)
        {
            primeProxy = new PrimeProxy();

            try
            {
                tcpChannel = TwoWaysServerTerminal.StartListening(Instance.Port, Instance.TcpChannelName, primeProxy, Instance.objURI);
                MessageBox.Show("Mở cổng thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            primeProxy.ChangColor();
        }

        private void BtnDongConnect_Click(object sender, EventArgs e)
        {
            primeProxy.EndChannel();
        }

        #endregion
    }
}
