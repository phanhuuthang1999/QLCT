using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyObject
{
    public static class Instance
    {
        public static int Port = 9999;

        public static string IPServer = "localhost";
        public static string objURI = "PRIME_URI";
        public static string TcpChannelName = "Demo1";

        #region Title

        public static string TitleServer = "QUẢN LÝ CHẤM THI";
        public static string NewSite = "Add New Site"; 
        #endregion
    }
}
