using ExerciseService.Data;
using ExerciseService.Models;

namespace ExerciseService.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ExerciseDbContext _context;

        public ExerciseRepository(ExerciseDbContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Add(user);
        }

        public IEnumerable<Exercise> GetExercisesForUser(int userId)
        {
            return _context.Exercises.Where(e => e.UserId == userId).ToList();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool UserExists(int userId)
        {
            return _context.Users.Any(u => u.Id == userId);
        }

        public bool ExternalUserExists(int externalUserId)
        {
            return _context.Users.Any(u => u.ExternalUserID == externalUserId);
        }
        public void CreateExercise(Exercise exercise)
        {
            if (exercise == null)
            {
                throw new ArgumentNullException(nameof(exercise));
            }

            _context.Exercises.Add(exercise);
        }

        public Exercise GetExerciseById(int id)
        {
            return _context.Exercises.FirstOrDefault(e => e.ExerciseId == id);
        }
    }
}