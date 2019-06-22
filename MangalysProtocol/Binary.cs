using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MangalysProtocol
{
    public class Binary
    {
        public static byte[] Serialize(Message message)
        {
            if (message == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, message);

            return ms.ToArray();
        }

        public static Message Deserialize(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();

            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);

            return (Message)binForm.Deserialize(memStream);
        }
    }
}
