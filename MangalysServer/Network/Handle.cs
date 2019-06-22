using MangalysProtocol;
using MangalysProtocol.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MangalysServer.Network
{
    public class Handle
    {
        private static List<Message> Messages = new List<Message>();
        private static List<MethodInfo> Methods = new List<MethodInfo>();
        public static void Setup()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();

            Messages.AddRange(types.Where(x => x.IsSubclassOf(typeof(Message)) && x.GetConstructor(Type.EmptyTypes) != null).Select(x => (Message)Activator.CreateInstance(x)));

            for (int i = 0; i < types.Length; i++)
            {
                Methods.AddRange(types[i].GetMethods());
            }

            //Console.WriteLine("Messages" + Environment.NewLine);

            //foreach (var msg in types)
            //{
            //    Console.WriteLine($"Message: {msg.GetType().Name}");
            //}
        }

        public static void Process(Client client, byte[] buffer) {

            Message message = Message.Deserialize(buffer);
            var messageAvailable = Messages.FirstOrDefault(x => x.GetType().Name == message.GetType().Name);

            if (messageAvailable == null)
            {
                Console.WriteLine("[RCV] {0}.", message.GetType().Name);
            }
            else
            {
                Console.WriteLine($"Search Message: {messageAvailable.Protocol}");
                var method = Methods.FirstOrDefault(x => x.Name == messageAvailable.GetType().Name);

                if (method == null)
                {
                    Console.WriteLine("[RCV] {0}.", method.Name);
                }
                else
                {
                    Console.WriteLine("[RCV] {0}.", message.GetType().Name);
                    method.Invoke(Activator.CreateInstance(method.DeclaringType), new object[] { client, messageAvailable });
                }
            }
        }
    }
}
