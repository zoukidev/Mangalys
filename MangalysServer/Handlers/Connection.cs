using MangalysProtocol.Messages;
using MangalysProtocol.Network;
using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;

namespace MangalysServer.Handlers
{
    public class Connection
    {
        public void BasicInfoMessage(Socket socket, MangalysProtocol.Messages.BasicInfoMessage message)
        {
            FormDispatcher.AddClient(message.MachineName, message.UserName);
        }
    }
}
