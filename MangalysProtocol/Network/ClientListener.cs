using MangalysProtocol.Enums;
using System;
using System.Net.Sockets;

namespace MangalysProtocol.Network
{
    public class ClientListener : Base
    {
        public delegate void OnStatusUpdateCallback(ClientStatusEnums status);
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
                OnStatusUpdate(ClientStatusEnums.ERROR);
                throw err;
            }
            
        }

        private void Connect(IAsyncResult asyncResult)
        {
            SocketInstance = (Socket)asyncResult.AsyncState;
            SocketInstance.EndConnect(asyncResult);

            OnStatusUpdate(ClientStatusEnums.ONLINE);

            SocketInstance.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(Receive), SocketInstance);
        }

        private void Receive(IAsyncResult asyncResult)
        {
            Socket socket = (Socket)asyncResult.AsyncState;

            try
            {
                int received = socket.EndReceive(asyncResult);
                byte[] dataBuf = new byte[received];
                Array.Copy(Buffer, dataBuf, received);

                OnReceive(dataBuf);

                socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(Receive), socket);
            }
            catch (Exception)
            {
                socket.Close();
                OnStatusUpdate(ClientStatusEnums.SERVER_OFFLINE);
            }
            
        }
    }
}
