using MangalysProtocol.Messages;
using MangalysProtocol.Network;

namespace MangalysServer.Handlers
{
    public class Connection
    {
        public void BasicInfoMessage(Client client, BasicInfoMessage message)
        {
            FormDispatcher.AppendLog(message.GetType().Name + " | " + message.Name);
        }

        public void BasicAnotherInfoMessage(Client client, BasicAnotherInfoMessage message)
        {
            FormDispatcher.AppendLog(message.GetType().Name + " | " + message.Name);
        }
    }
}
