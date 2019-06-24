using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace MangalysProtocol.Network
{
    public class ServerListener : BaseListener
    {
        public delegate void OnStatusUpdateCallback(string status);
        public delegate void OnAcceptCallback(Socket socket);
        public delegate void OnReceiveCallback(Socket socket, byte[] buffer);
        
        public OnStatusUpdateCallback OnStatusUpdate;
        public OnAcceptCallback OnAccept;
        public OnReceiveCallback OnReceive;

        public List<Socket> Clients = new List<Socket>();

        public void Start(string ip, int port)
        {
            try
            {
                SocketInstance = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                SocketInstance.Bind(CreateIPEndPoint($"{ip}:{port}"));
                //SocketInstance.Bind(new IPEndPoint(IPAddress.Any, 3000));
                SocketInstance.Listen(5);

                OnStatusUpdate("Server en ligne");
                SocketInstance.BeginAccept(new AsyncCallback(Accept), null);
            }
            catch (Exception err)
            {
                OnStatusUpdate(err.ToString());
                throw;
            }
        }

        private void Accept(IAsyncResult asyncResult)
        {
            Socket socket = SocketInstance.EndAccept(asyncResult);
            //Client client = new Client(socket);
            OnAccept(socket);
            Clients.Add(socket);

            socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(Receive), socket);
            SocketInstance.BeginAccept(new AsyncCallback(Accept), null);
        }

        private void Receive(IAsyncResult asyncResult)
        {
            Socket socket = (Socket)asyncResult.AsyncState;

            int received = socket.EndReceive(asyncResult);
            byte[] dataBuf = new byte[received];
            Array.Copy(Buffer, dataBuf, received);

            OnReceive(socket, dataBuf);

            socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(Receive), socket);
        }
    }
}
