using MangalysProtocol;
using System;

namespace MangalysProtocol.Messages
{
    [Serializable]
    public class BasicInfoMessage : Message
    {
        public new int Protocol = 1;
        public string Name { get; set; }

        public BasicInfoMessage(string name)
        {
            Name = name;
        }
    }
}
