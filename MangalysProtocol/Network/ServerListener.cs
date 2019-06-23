using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MangalysProtocol.Network
{
    public class ServerListener : BaseListener
    {
        public delegate void OnStatusUpdateCallback(string status);
        public delegate void OnAcceptCallback(Client client);
        public delegate void OnReceiveCallback(Client client, byte[] buffer);
        
        public OnStatusUpdateCallback OnStatusUpdate;
        public OnAcceptCallback OnAccept;
        public OnReceiveCallback OnReceive;

        public void Start(string ip, int port)
        {
            try
            {
                SocketInstance = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                SocketInstance.Bind(CreateIPEndPoint($"{ip}:{port}"));
                SocketInstance.Listen(1);

                OnStatusUpdate("Server en ligne");
            }
            catch (Exception err)
            {
                OnStatusUpdate(err.ToString());
                throw;
            }

            SocketInstance.BeginAccept(new AsyncCallback(Accept), SocketInstance);
        }

        private void Accept(IAsyncResult asyncResult)
        {
            SocketInstance = (Socket)asyncResult.AsyncState;
            Socket socket = SocketInstance.EndAccept(asyncResult);
            Client client = new Client(socket);
            OnAccept(client);

            client.Socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(Receive), client.Socket);
        }

        private void Receive(IAsyncResult asyncResult)
        {
            Socket SocketClient = (Socket)asyncResult.AsyncState;
            Client client = new Client(SocketClient);
            int read = SocketClient.EndReceive(asyncResult);

            OnReceive(client, Buffer);
            Buffer = new byte[2048];

            client.Socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(Receive), client.Socket);
        }
    }
}
