using MangalysProtocol;
using MangalysProtocol.Network;
using MangalysServer.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MangalysServer.Network
{
    public class Handle
    {
        private static List<MangalysServer.Messages.Message> Messages = new List<MangalysServer.Messages.Message>();
        private static List<MethodInfo> Methods = new List<MethodInfo>();

        public static void Setup()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();

            Messages.AddRange(types.Where(x => x.IsSubclassOf(typeof(MangalysServer.Messages.Message)) && x.GetConstructor(Type.EmptyTypes) != null).Select(x => (MangalysServer.Messages.Message)Activator.CreateInstance(x)));

            for (int i = 0; i < types.Length; i++)
            {
                Methods.AddRange(types[i].GetMethods());
            }
        }

        public static void Process(Client client, byte[] buffer) {

            MangalysProtocol.Message msg = (MangalysProtocol.Message)Binary.Deserialize(buffer);
            var message = Messages.FirstOrDefault(x => x.Protocol == msg.Protocol);

            if (message == null)
            {
                Console.WriteLine("[RCV] {0}.", msg.Protocol);
            }
            else
            {
                Console.WriteLine($"Search Message: {message.Protocol}");
                var method = Methods.FirstOrDefault(x => x.Name == message.GetType().Name);

                if (method == null)
                {
                    Console.WriteLine("[RCV] {0}.", msg.Protocol);
                }
                else
                {
                    //Console.WriteLine($"Search Method: {method.GetType().Name}");
                    //message.Deserialize(reader);
                    //Console.WriteLine("[RCV] {0}.", message.GetType().Name);
                    method.Invoke(Activator.CreateInstance(method.DeclaringType), new object[] { client, message });
                }
            }
        }

    }
}
