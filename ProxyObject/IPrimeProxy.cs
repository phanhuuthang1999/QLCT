using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyObject
{
    [Serializable]
    public delegate void ChangeColor();
    public delegate void EndChannel();

    public interface IPrimeProxy
    {
        void ChangColor();
        void EndChannel();

        event ChangeColor ChangeReceived;
        event EndChannel EndReceived;
    }

}
