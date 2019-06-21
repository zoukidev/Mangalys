using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MangalysProtocol.Network
{
    public class ClientListener : BaseListener
    {
        public delegate void OnStatusUpdateCallback(string status);
        public delegate void OnReceiveCallback(byte[] buffer);

        public OnStatusUpdateCallback OnStatusUpdate;
        public OnReceiveCallback OnReceive;

        public void Start(string ip, int port)
        {
            try
            {
                SocketInstance = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                SocketInstance.BeginConnect(CreateIPEndPoint($"{ip}:{port}"), new AsyncCallback(Connect), SocketInstance);
            }
            catch (Exception err)
            {
                OnStatusUpdate(err.ToString());
            }
            
        }

        private void Connect(IAsyncResult asyncResult)
        {
            SocketInstance = (Socket)asyncResult.AsyncState;
            SocketInstance.EndConnect(asyncResult);

            OnStatusUpdate("Connected");

            SocketInstance.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(Receive), SocketInstance);
        }

        private void Receive(IAsyncResult asyncResult)
        {
            SocketInstance = (Socket)asyncResult.AsyncState;
            int read = SocketInstance.EndReceive(asyncResult);

            if (read > 0)
            {
                //string msg = Encoding.ASCII.GetString(Buffer);

                //OnReceive(Buffer);
                Buffer = new byte[2048];

                SocketInstance.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(Receive), SocketInstance);
            }
        }

        public void Send(Message message)
        {
            SocketInstance.Send(Message.Serialize(message));
        }
    }
}
