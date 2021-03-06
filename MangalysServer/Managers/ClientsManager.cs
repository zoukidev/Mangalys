﻿using MangalysServer.Network;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace MangalysServer.Managers
{
    public class ClientsManager
    {
        public static List<Client> Clients = new List<Client>();

        public static Client Find(Socket socket)
        {
            return Clients.FirstOrDefault(x => x.Socket == socket);
        }

        public static IEnumerable<Client> FindClientsForBroadcasting(Client client)
        {
            return Clients.Where(x => x != client);
        }
    }
}
