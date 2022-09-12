namespace UserService.DTOs.RabbitMQ
{
    public class UserPublishedDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Event { get; set; }

    }
}