using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace QLCT_Server
{
    public class TwoWaysServerTerminal
    {

        public static TcpChannel StartListening(int port, string tcpChannelName,
          MarshalByRefObject remoteObject, string remoteObjectUri)
        {
            TcpChannel channel = CreateTcpChannel(port, tcpChannelName);

            ChannelServices.RegisterChannel(channel, false);

            RemotingServices.Marshal(remoteObject, remoteObjectUri);

            return channel;
        }

        private static TcpChannel CreateTcpChannel(int port, string tcpChannelName)
        {
            BinaryServerFormatterSinkProvider serverFormatter =
                new BinaryServerFormatterSinkProvider();

            serverFormatter.TypeFilterLevel = TypeFilterLevel.Full;

            BinaryClientFormatterSinkProvider clientProv =
                new BinaryClientFormatterSinkProvider();

            Hashtable props = new Hashtable();
            props["port"] = port;
            props["name"] = tcpChannelName;

            return new TcpChannel(
                props, clientProv, serverFormatter);
        }

    }
}
