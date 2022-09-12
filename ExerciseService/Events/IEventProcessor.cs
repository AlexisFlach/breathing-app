namespace ExerciseService.Events
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);
    }
}