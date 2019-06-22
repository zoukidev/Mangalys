using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MangalysProtocol
{
    [Serializable]
    public class Message
    {
        public int Protocol { get; set; }

        public static byte[] Serialize(Message message)
        {
            if (message == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, message);

            return ms.ToArray();
        }

        public static Object Deserialize(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = binForm.Deserialize(memStream);

            return obj;
        }
    }
}
