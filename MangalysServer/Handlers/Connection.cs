using MangalysProtocol.Network;

namespace MangalysServer.Handlers
{
    public class Connection
    {
        public void BasicInfoMessage(Client client, BasicInfoMessage message)
        {
            FormDispatcher.AppendLog("BasicInfoMessage:" + message.SpecialName);
        }
    }
}
