using MangalysProtocol.Messages;
using MangalysProtocol.Network;
using System;
using System.Drawing;
using System.IO;

namespace MangalysServer.Handlers
{
    public class Connection
    {
        public void BasicInfoMessage(Client client, BasicInfoMessage message)
        {
            FormDispatcher.AppendLog("BasicInfoMessage:" + message.SpecialName);
        }

        public void BasicVideoMessage(Client client, BasicVideoMessage message)
        {
            FormDispatcher.AppendLog("BasicVideoMessage");
            try
            {
                FormDispatcher.PictureBox.Image = ToImage(message.Image);
            }
            catch (Exception err)
            {
                FormDispatcher.AppendLog("BasicVideoMessage Error: "+ err.ToString());
            }
        }

        public Bitmap ToImage(byte[] array)
        {
            MemoryStream ms = new MemoryStream(array);
            return new Bitmap(ms);
        }
    }
}
