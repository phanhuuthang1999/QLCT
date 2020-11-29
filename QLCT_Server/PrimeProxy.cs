using ProxyObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCT_Server
{
    public class PrimeProxy : MarshalByRefObject, IPrimeProxy
    {
        public event EndChannel EndReceived;
        public event GetConnection ConnectReceived;
        public event GetLogin LoginReceived;
       // public event CreateSite SiteReceived;
        public event NopBai NopBaiReceived;
        public event ReceiveResult ReceivedResult;

        #region Server

        public int CreateSite()
        {
            return 1;
        }
        public void EndChannel()
        {

        }

        #endregion

        #region Thí sinh

        public void NopBai()
        {

        }

        #endregion

        #region Dùng chung
        public bool GetLogin(string taikhoan, string matkhau)
        {
            return true;
        }
        public void GetConnection()
        {
            Delegate[] invocationList = ConnectReceived.GetInvocationList();

            foreach (GetConnection item in invocationList)
            {
                try
                {
                    item();
                }
                catch (Exception)
                {

                    ConnectReceived -= item;
                }
            }
        }

        public void ReceiveResult()
        {

        }
        #endregion
    }
}
