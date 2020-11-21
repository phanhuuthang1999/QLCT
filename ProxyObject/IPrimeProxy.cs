using System;

namespace ProxyObject
{

    #region Delegate

    #region Server

    [Serializable]
    public delegate void EndChannel();
    public delegate int CreateSite();
    public delegate void CreateExam();
    public delegate int GetResult();

    #endregion

    #region Thí Sinh

    [Serializable]
    public delegate void NopBai();

    #endregion

    #region Dùng chung

    [Serializable]
    public delegate bool GetLogin(string taikhoan, string matkhau);
    public delegate void GetConnection();

    #endregion

    #endregion

    #region Interface

    public interface IPrimeProxy
    {
        #region Private

        #region Server

        void EndChannel();
        int CreateSite();

        #endregion

        #region Thí sinh 

        void NopBai();

        #endregion

        #region Dùng chung
        bool GetLogin(string taikhoan, string matkhau);

        #endregion

        #endregion

        #region Events

        #region Server

        event EndChannel EndReceived;
        event CreateSite SiteReceived;

        #endregion

        #region Thí sinh

        event NopBai NopBaiReceived;

        #endregion

        #region Dùng chung

        event GetLogin LoginReceived;
        event GetConnection ConnectReceived;

        #endregion

        #endregion
    }

    #endregion
}
