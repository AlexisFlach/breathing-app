using UserService.DTOs.RabbitMQ;

namespace UserService.RabbitMQ
{
    public interface IMessageBusClient
    {
        void PublishNewUser(UserPublishedDto user);     
    }
}
