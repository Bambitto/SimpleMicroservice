using BookService.Dtos;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace BookService.AsyncDataServices
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MessageBusClient(IConfiguration configuration)
        {
            _configuration = configuration;
            var factory = new ConnectionFactory() { HostName = _configuration["RabbitMQHost"],
                Port = int.Parse(_configuration["RabbitMQPort"]) };
            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);

                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> Could not connect to the Message Bus: {ex.Message}");
            }
        }
        public void PublishBook(BookPublishDto bookPublishDto)
        {
            var message = JsonSerializer.Serialize(bookPublishDto);

            if(_connection.IsOpen)
            {
                SendMessage(message);
            }
            else
            {
            }
        }

        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "trigger",
                            routingKey: "",
                            basicProperties: null,
                            body: body);
            Console.WriteLine($"Message: {message} was sent");
        }

        public void Dispose()
        {
            if(_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs args)
        {
            Console.WriteLine("RabbitMQ connection shutdown");
        }
    }
}
