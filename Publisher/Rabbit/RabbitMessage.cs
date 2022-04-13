using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Publisher.Rabbit
{
    public class RabbitMessage : IMessage
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory
            {                
                Uri = new Uri("amqps://znykepbk:0Ze9VXfUsrEfbl5xuTK3vy1uIR4GG3bo@fly.rmq.cloudamqp.com/znykepbk")
            };

            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("mensagens", exclusive: false);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "mensagens", body: body);
        }
    }
}

