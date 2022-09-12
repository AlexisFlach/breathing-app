namespace ExerciseService.Models
{
    public class Level
    {
        public int LevelId { get; set; }
        public string Name { get; set; }
        public LevelDetails LevelDetails { get; set; }
        public int LevelDetailsId { get; set; }
    }

   
}