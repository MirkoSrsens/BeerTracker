using NetworkService.Rmq;
using System;
using System.Linq;

namespace NetworkService
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var type = typeof(NetworkServiceMessageHandler);
            //var interfaces = type.GetInterfaces().SelectMany(x=> x.GetMethods());

            //var methods = typeof(NetworkServiceMessageHandler).GetMethods().Where(x => interfaces.Any(y=> y.Name == x.Name));

            //var rmqTransport = new RmqTransport();

            //var charr = Console.ReadKey().KeyChar;

            //var handler = new NetworkServiceMessageHandler();

            //if (charr == 'c')
            //{
            //    rmqTransport.Subscribe<PlayerData>(handler);
            //}
            //if (charr == 's')
            //{
            //    rmqTransport.SendMessage<NetworkServiceMessageHandler, PlayerData>(new PlayerData());
            //}
        }
    }
}
