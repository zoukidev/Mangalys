using MangalysServer.Managers;

namespace MangalysServer.Handlers
{
    public class Connection
    {
        public void BasicInfoMessage(Network.Client client, MangalysProtocol.Messages.BasicInfoMessage message)
        {
            client.MachineName = message.MachineName;
            client.UserName = message.UserName;

            FormDispatcher.RefreshList(ClientsManager.Clients.ToArray());
        }
    }
}
