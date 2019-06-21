using System;

namespace MangalysProtocol.Messages
{
    [Serializable]
    public class BasicAnotherInfoMessage : BasicInfoMessage
    {
        public new int Protocol = 2;
        public BasicAnotherInfoMessage(string name) : base(name) { }
    }
}
