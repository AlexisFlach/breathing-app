namespace ExerciseService.Models
{
    public class LevelDetails
    {
        public int LevelDetailsId { get; set; }
        public int Inhale { get; set; }
        public int Exhale { get; set; }
        public int Duration { get; set; }

        public Level Level { get; set; }
    }
}