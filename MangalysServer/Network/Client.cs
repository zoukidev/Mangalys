using MangalysProtocol;
using MangalysServer.Managers;
using System.Collections.Generic;
using System.Net.Sockets;

namespace MangalysServer.Network
{
    public class Client
    {
        public Socket Socket;
        public string MachineName;
        public string UserName;

        public Client(Socket socket)
        {
            Socket = socket;
        }

        public void Send(Message message)
        {
            Socket.Send(Binary.Serialize(message));
        }

        public void Broadcast(Message message)
        {
            IEnumerable<Client> clients = ClientsManager.FindClientsForBroadcasting(this);

            foreach (Client client in clients)
            {
                client.Send(message);
            }
        }
    }
}
