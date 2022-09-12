namespace UserService.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public Level Level { get; set; }
        public int LevelId { get; set; }
        public bool IsFinished { get; set; }
        public DateTime StartedAt { get; set; }
        public User? User { get; set; }
    }
}