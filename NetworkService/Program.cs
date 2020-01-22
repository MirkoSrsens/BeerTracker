using NetworkService.Messages;
using NetworkService.Rmq;
using System;
using System.Linq;
using System.Threading;

namespace NetworkService
{
    public class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(NetworkServiceMessageHandler);
            var interfaces = type.GetInterfaces().SelectMany(x => x.GetMethods());

            var methods = typeof(NetworkServiceMessageHandler).GetMethods().Where(x => interfaces.Any(y => y.Name == x.Name));

            var rmqTransport = new RmqTransport();
            var handler = new NetworkServiceMessageHandler();


            rmqTransport.Subscribe<EquipmentMessage>(handler);

            for(int i = 0; i< 10; i++)
            {
                var equipment = new EquipmentMessage()
                {
                    Id = "Tank" + i,
                    State = "Holding",
                    CurrentCapacity = 272 * i,
                    LastInspectionDate = null,
                    MaxCapacity = 523 * i,
                };

                Console.WriteLine(equipment.Id);
                Thread.Sleep(1000);

                rmqTransport.SendMessage<NetworkServiceMessageHandler, EquipmentMessage>(equipment);
            }
        }
    }
}
