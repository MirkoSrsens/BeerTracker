using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace NetworkService.Rmq
{
    public class RmqTransport : IRmqTransport
    {
        List<EventingBasicConsumer> consumers = new List<EventingBasicConsumer>();

        private IConnection connection { get; set; }

        private IModel channel { get; set; }

        public RmqTransport()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
        }

        public void SendMessage<I,T>(T message)
        {

                var routingKey = typeof(T).FullName;
                var exchangeName = typeof(I).FullName;
                channel.ExchangeDeclare(exchange: exchangeName,
                                        type: "topic");


                var body = ObjectToByteArray<T>(message);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                
                channel.BasicPublish(exchange: exchangeName,
                                     routingKey: routingKey,
                                     basicProperties: properties,
                                     body: body);
                Console.WriteLine(" [x] Sent '{0}':'{1}'", routingKey, body);
        }


        public void Subscribe<T>(object instance)
        {
            var methodInfo = instance
                .GetType()
                .GetMethods()
                .FirstOrDefault(x => x.GetParameters().Length == 1 && x.GetParameters()[0].ParameterType.FullName == typeof(T).FullName);


            var exchangeName = instance.GetType().FullName;
            channel.ExchangeDeclare(exchange: exchangeName,
                                    type: "topic");

            var queueName = channel.QueueDeclare().QueueName;

            var routingKey = typeof(T).FullName;

            channel.QueueBind(queue: queueName,
                              exchange: exchangeName,
                              routingKey: routingKey);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;

                var message = FromByteArray<T>(body);

                methodInfo.Invoke(instance, parameters: new object[] { message });
            };

            consumers.Add(consumer);

            channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine("Client connected topic key is {0}", routingKey);
        }

        private static T FromByteArray<T>(byte[] data)
        {
            if (data == null)
                return default(T);
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }

        private static byte[] ObjectToByteArray<T>(T obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}
