using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace MangalysProtocol.Network
{
    public class Client
    {
        public Socket Socket { get; set; }

        public Client(Socket socket)
        {
            Socket = socket;
        }

        public void Send(byte[] buffer)
        {
            Socket.Send(buffer);
        }
    }
}
