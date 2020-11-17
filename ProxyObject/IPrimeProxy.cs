using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyObject
{
    [Serializable]
    public delegate void GetConnection();
    public delegate void EndChannel();
    public delegate int CreateSite();
    public delegate bool GetLogin(string taikhoan, string matkhau);
    public delegate void CreateExam();
    public delegate int GetResult();

    public interface IPrimeProxy
    {
        void EndChannel();
        bool GetLogin(string taikhoan, string matkhau);
        //   int CreateSite();

        event EndChannel EndReceived;
        //   event CreateSite SiteReceived;

        event GetConnection ConnectReceived;

        event GetLogin LoginReceived;
    }

}
