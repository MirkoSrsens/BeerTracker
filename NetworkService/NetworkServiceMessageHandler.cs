using DatabaseModels;
using NetworkService.Messages;
using NetworkService.Rmq;
using System;
using System.Linq;

namespace NetworkService
{
    public class NetworkServiceMessageHandler : IHandle<EquipmentMessage>
    {
        public NetworkServiceMessageHandler()
        {
        }

        public void Handle(EquipmentMessage message)
        {
            using(var context = new MainContext())
            {
                context.Database.Log = Console.Write;
                var first = context.Equipment.First();
                context.Set<Equipment>().Add(MapToModel(message));
                context.SaveChanges();
            }
        }

        private Equipment MapToModel(EquipmentMessage message)
        {
            return new Equipment()
            {
                Id = message.Id,
                State = message.State,
                CurrentCapacity = message.CurrentCapacity,
                LastInspectionDate = message.LastInspectionDate,
                MaxCapacity = message.MaxCapacity
            };
        }
    }
}
