using System.Text.Json;
using AutoMapper;
using ExerciseService.Dtos;
using ExerciseService.Models;
using ExerciseService.Repositories;

namespace ExerciseService.Events
{
   public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, AutoMapper.IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }

        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.UserPublished:
                    addUser(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notifcationMessage)
        {
            Console.WriteLine("--> Determining Event");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notifcationMessage);

            switch(eventType.Event)
            {
                case "User_Published":
                    Console.WriteLine("--> User Published Event Detected");
                    return EventType.UserPublished;
                default:
                    Console.WriteLine("--> Could not determine the event type");
                    return EventType.Undetermined;
            }
        }

        private void addUser(string userPublishedMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IExerciseRepository>();
                
                var userPublishedDto = JsonSerializer.Deserialize<UserPublishedDto>(userPublishedMessage);

                try
                {
                    var user = _mapper.Map<User>(userPublishedDto);
                    if(!repo.ExternalUserExists(user.ExternalUserID))
                    {
                        repo.CreateUser(user);
                        repo.SaveChanges();
                        Console.WriteLine("--> User added!");
                    }
                    else
                    {
                        Console.WriteLine("--> User already exisits...");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not add User to DB {ex.Message}");
                }
            }
        }
    }

    enum EventType
    {
        UserPublished,
        Undetermined
    }
}