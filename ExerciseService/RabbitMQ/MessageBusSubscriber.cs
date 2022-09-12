using System.Text;
using ExerciseService.Events;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ExerciseService.RabbitMQ
{
    public class MessageBusSubscriber : BackgroundService
    {
        private readonly IConfiguration _config;
        private readonly IEventProcessor _eventProcessor;
        private IConnection _connection;
        private IModel _channel;
        private string _queueName;

        public MessageBusSubscriber(IConfiguration config, IEventProcessor eventProcessor)
        {
            _config = config;
            System.Console.WriteLine(_config["RabbitMQHost"]);
            System.Console.WriteLine(_config["RabbitMQPort"]);
            _eventProcessor = eventProcessor;

            InitializeRabbitMQ();
        }

        private void InitializeRabbitMQ()
        {
            var factory = new ConnectionFactory() {HostName = _config["RabbitMQHost"], Port = int.Parse(_config["RabbitMQPort"])};
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
            _queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _queueName,
            exchange: "trigger",
            routingKey: ""
            );
            System.Console.WriteLine("--> Listening on the Message Bus");

            _connection.ConnectionShutdown += RabbitMQ_ConnectionShotdown;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (ModuleHandle, ea) => 
            {
                System.Console.WriteLine("--> Event Received");

                var body = ea.Body;
                var notification = Encoding.UTF8.GetString(body.ToArray());
                _eventProcessor.ProcessEvent(notification);
            };

            _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }

        private void RabbitMQ_ConnectionShotdown(object sender, ShutdownEventArgs e)
        {
            System.Console.WriteLine("--> Connection shut down");
        }
        public override void Dispose()
        {   

            if(_channel.IsOpen) {
                _channel.Close();
                _connection.Close();
            }
            base.Dispose();
        }
    }
}