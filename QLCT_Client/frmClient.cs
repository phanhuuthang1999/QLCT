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
#pragma warning disable CS0169 // The field 'frmClient.type' is never used
        Type type;
#pragma warning restore CS0169 // The field 'frmClient.type' is never used
        IPrimeProxy primeProxy;
        TwoWaysClientTerminal twoWaysClientTerminal;
#pragma warning disable CS0169 // The field 'frmClient.tcpChannel' is never used
        TcpChannel tcpChannel;
#pragma warning restore CS0169 // The field 'frmClient.tcpChannel' is never used
        #endregion

        #region Constructor

        public frmClient()
        {
            InitializeComponent();
            ins = this;
            btnConnect.Click += BtnConnect_Click;
            button1.Click += Button1_Click;

            twoWaysClientTerminal = new TwoWaysClientTerminal();
        }

        #endregion

        #region Protected

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            lblTitle.Text = Instance.TitleClient;
        }

        #endregion

        #region Events

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {

                primeProxy = twoWaysClientTerminal.Connect<IPrimeProxy>(Instance.IPServer, Instance.Port, Instance.objURI, Instance.TcpChannelName);

                ClientEventsWrapper clientEventsWrapper = new ProxyObject.ClientEventsWrapper();

                primeProxy.EndReceived += clientEventsWrapper.EndChannelReceiveHandler;
                primeProxy.ConnectReceived += clientEventsWrapper.ConnectionReceiveHandler;

                clientEventsWrapper.ConnectionReceived += ClientEventsWrapper_ConnectionReceived;
                clientEventsWrapper.EndChannelReceived += ClientEventsWrapper_EndChannelReceived;
                UICommon.ShowMsgInfoString("Kết nối thành công");
            }
            catch (Exception ex)
            {
                UICommon.ShowMsgErrorString(ex.Message);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            EndChannel();
        }

        private void ClientEventsWrapper_ConnectionReceived()
        {
            Connect();
        }

        private void Connect()
        {

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
            EndChannel();
        }

        #endregion
    }
}
