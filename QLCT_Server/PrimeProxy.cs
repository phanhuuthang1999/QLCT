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
        public event ChangeColor ChangeReceived;
        public event EndChannel EndReceived;

        public void ChangColor()
        {
            Delegate[] invocationList = ChangeReceived.GetInvocationList();

            foreach (ChangeColor item in invocationList)
            {
                try
                {
                    item();
                }
                catch (Exception)
                {

                    ChangeReceived -= item;
                }
            }
        }

        public void EndChannel()
        {
            Delegate[] invocationList = EndReceived.GetInvocationList();

            foreach (EndChannel item in invocationList)
            {
                try
                {
                    item();
                }
                catch (Exception)
                {

                    EndReceived -= item;
                }
            }
        }
    }
}
