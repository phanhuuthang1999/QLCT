using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyObject
{
    public class ClientEventsWrapper : MarshalByRefObject
    {
        public event ChangeColor ChangeColorReceived;
        public event EndChannel EndChannelReceived;

        public void ChangeColorReceiveHandler()
        {
            if (ChangeColorReceived != null)
            {
                ChangeColorReceived();
            }
        }

        public void EndChannelReceiveHandler()
        {
            if (EndChannelReceived != null)
            {
                EndChannelReceived();
            }
        }

    }
}
