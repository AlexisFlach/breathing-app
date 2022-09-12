namespace ExerciseService.Dtos
{
    public class ExerciseReadDto
{
    public int Id { get; set; }
    public int LevelId { get; set; }

    public int UserId { get; set; }

    public bool IsFinished { get; set; }

    public DateTime StartedAt { get; set; }
    }
}