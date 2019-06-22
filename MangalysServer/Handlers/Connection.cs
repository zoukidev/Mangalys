using MangalysProtocol.Network;
using MangalysServer.Messages;

namespace MangalysServer.Handlers
{
    public class Connection
    {
        public void BasicInfoMessage(Client client, BasicInfoMessage message)
        {
            FormDispatcher.AppendLog("OK: " + message.GetType().Name + " | " + message.Name);
        }
    }
}
