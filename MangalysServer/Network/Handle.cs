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

            foreach (MangalysServer.Messages.Message message in Messages)
            {
                Console.WriteLine($"Message Loaded: {message.GetType().Name}");
            }
        }

        public static void Process(Client client, byte[] buffer) {
            Console.WriteLine("[RCV] Buffer Length {0}.", buffer.Length);
            MangalysProtocol.Message msg = (MangalysProtocol.Message)Binary.Deserialize(buffer);

            var message = Messages.FirstOrDefault(x => x.GetType().Name == msg.GetType().Name);

            if (message == null)
            {
                Console.WriteLine("[RCV] {0}.", msg.Protocol);
            }
            else
            {
                var method = Methods.FirstOrDefault(x => x.Name == message.GetType().Name);

                if (method == null)
                {
                    Console.WriteLine("[RCV] {0}.", msg.Protocol);
                }
                else
                {
                    method.Invoke(Activator.CreateInstance(method.DeclaringType), new object[] { client, message });
                }
            }
        }

    }
}
