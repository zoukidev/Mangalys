using MangalysProtocol.Enums;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace MangalysProtocol.Network
{
    public class ServerListener : Base
    {
        public delegate void OnNewClientCallback(Socket socket);
        public delegate void OnClientDisconnectCallback(Socket socket);
        public delegate void OnStatusUpdateCallback(ServerStatusEnums status);
        public delegate void OnReceiveCallback(Socket socket, byte[] buffer);

        public OnNewClientCallback OnNewClient;
        public OnClientDisconnectCallback OnClientDisconnect;
        public OnStatusUpdateCallback OnStatusUpdate;
        public OnReceiveCallback OnReceive;

        public void Start(string ip, int port)
        {
            try
            {
                SocketInstance = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                SocketInstance.Bind(CreateIPEndPoint($"{ip}:{port}"));
                SocketInstance.Listen(5);

                OnStatusUpdate(ServerStatusEnums.ONLINE);
                SocketInstance.BeginAccept(new AsyncCallback(Accept), null);
            }
            catch (Exception err)
            {
                OnStatusUpdate(ServerStatusEnums.ERROR);
                throw err;
            }
        }

        private void Accept(IAsyncResult asyncResult)
        {
            Socket socket = SocketInstance.EndAccept(asyncResult);
            OnNewClient(socket);

            socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(Receive), socket);
            SocketInstance.BeginAccept(new AsyncCallback(Accept), null);
        }

        private void Receive(IAsyncResult asyncResult)
        {
            Socket socket = (Socket)asyncResult.AsyncState;
            try
            {
                int received = socket.EndReceive(asyncResult);
                byte[] dataBuf = new byte[received];
                Array.Copy(Buffer, dataBuf, received);

                OnReceive(socket, dataBuf);

                socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(Receive), socket);
            }
            catch (Exception)
            {
                OnClientDisconnect(socket);
                socket.Close();
            }
        }
    }
}
