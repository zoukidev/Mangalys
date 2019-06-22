using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MangalysProtocol
{
    [System.Serializable]
    public class Message
    {
        public int Protocol { get; set; }
    }
}
