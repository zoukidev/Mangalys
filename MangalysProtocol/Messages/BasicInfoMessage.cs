using MangalysProtocol;
using System;

namespace MangalysProtocol.Messages
{
    [Serializable()]
    public class BasicInfoMessage : Message
    {
        public new int Protocol = 1;
        public string SpecialName { get; set; }

        public BasicInfoMessage() { }

        public BasicInfoMessage(string name)
        {
            SpecialName = name;
        }
    }
}
