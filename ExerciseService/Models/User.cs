using System.ComponentModel.DataAnnotations;

namespace ExerciseService.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]

        public int ExternalUserID { get; set; }

        [Required]
        public string Name { get; set; }
        public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}