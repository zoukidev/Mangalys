using System;
using System.Globalization;
using System.Net;
using System.Net.Sockets;

namespace MangalysProtocol.Network
{
    public class Base
    {
        public byte[] Buffer = new byte[1024];
        public Socket SocketInstance;

        public static IPEndPoint CreateIPEndPoint(string endPoint)
        {
            string[] ep = endPoint.Split(':');
            IPAddress ip;
            int port;

            if (ep.Length != 2) throw new FormatException("Invalid endpoint format");

            if (!IPAddress.TryParse(ep[0], out ip))
            {
                throw new FormatException("Invalid ip-adress");
            }
            
            if (!int.TryParse(ep[1], NumberStyles.None, NumberFormatInfo.CurrentInfo, out port))
            {
                throw new FormatException("Invalid port");
            }

            return new IPEndPoint(ip, port);
        }

        public void Send(Message message)
        {
            SocketInstance.Send(Binary.Serialize(message));
        }
    }
}
