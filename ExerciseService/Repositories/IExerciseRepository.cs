using ExerciseService.Models;

namespace ExerciseService.Repositories
{
    public interface IExerciseRepository
    {
        bool SaveChanges();

        IEnumerable<User> GetAllUsers();
        IEnumerable<Exercise> GetExercisesForUser(int userId);
        bool ExternalUserExists(int externalUserId);

        Exercise GetExerciseById(int id);

        void CreateExercise(Exercise exercise);

        bool UserExists(int userId);
        void CreateUser(User user);
    }
}