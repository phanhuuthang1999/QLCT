using ProxyObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCT_Client
{
    public partial class frmClient : Form
    {
        #region Variable

        public static frmClient ins;
        Type type;
        IPrimeProxy primeProxy;
        TwoWaysClientTerminal twoWaysClientTerminal;
        TcpChannel tcpChannel;
        #endregion

        #region Constructor

        public frmClient()
        {
            InitializeComponent();
            ins = this;
            btnConnect.Click += BtnConnect_Click;
        }

        #endregion

        #region Events

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                twoWaysClientTerminal = new TwoWaysClientTerminal();
                primeProxy = twoWaysClientTerminal.Connect<IPrimeProxy>(Instance.IPServer, Instance.Port, Instance.objURI, Instance.TcpChannelName);

                ClientEventsWrapper clientEventsWrapper = new ProxyObject.ClientEventsWrapper();
                primeProxy.ChangeReceived += clientEventsWrapper.ChangeColorReceiveHandler;
                primeProxy.EndReceived += clientEventsWrapper.EndChannelReceiveHandler;

                clientEventsWrapper.ChangeColorReceived += PrimeProxy_ChangeReceived;
                clientEventsWrapper.EndChannelReceived += ClientEventsWrapper_EndChannelReceived;
                MessageBox.Show("Kết nối thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClientEventsWrapper_EndChannelReceived()
        {
            EndChannel();
        }

        private void EndChannel()
        {
            twoWaysClientTerminal.Disconnect();
        }

        private void PrimeProxy_ChangeReceived()
        {
            ChangeColor();
        }

        private void ChangeColor()
        {
            ChangeColor(Color.Red);
        }

        private void ChangeColor(Color red)
        {
            button1.Invoke(new MethodInvoker(() => button1.ForeColor = red));
        }

        #endregion
    }
}
