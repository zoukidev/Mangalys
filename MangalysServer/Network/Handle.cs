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
            IEnumerable<string> Messagess = GetClasses("MangalysServer.Messages");

            foreach (var message in Messagess)
            {
                Console.WriteLine(message.GetType().Name);
            }
        }

        public static void Process(Client client, byte[] buffer) {

            Message message = Message.Deserialize(buffer);
            var messageAvailable = Messages.FirstOrDefault(x => x.GetType().Name == message.GetType().Name);

            if (messageAvailable == null)
            {
                Console.WriteLine("[RCV][Message] {0}.", message.Protocol);
            }
            else
            {
                Console.WriteLine($"Search Message: {messageAvailable.Protocol}");
                var method = Methods.FirstOrDefault(x => x.Name == messageAvailable.GetType().Name);

                if (method == null)
                {
                    Console.WriteLine("[RCV][Method] {0}.", method.Name);
                }
                else
                {
                    Console.WriteLine("[RCV] {0}.", message.GetType().Name);
                    method.Invoke(Activator.CreateInstance(method.DeclaringType), new object[] { client, messageAvailable });
                }
            }
        }

        static IEnumerable<string> GetClasses(string nameSpace)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            return asm.GetTypes()
                .Where(type => type.Namespace == nameSpace)
                .Select(type => type.Name);
        }
    }
}
