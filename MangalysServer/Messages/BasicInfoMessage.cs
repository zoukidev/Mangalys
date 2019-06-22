using System;

namespace MangalysServer.Messages
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
