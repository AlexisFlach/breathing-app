using ExerciseService.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseService.Data
{
    public class ExerciseDbContext : DbContext
    {

        public ExerciseDbContext() { }
        public ExerciseDbContext(DbContextOptions<ExerciseDbContext> opt) : base(opt) { }
        public DbSet<Exercise>Exercises{ get; set; }
        public DbSet<User>Users{ get; set; }
        public DbSet<Level>Levels { get; set; }
        public DbSet<LevelDetails>LevelDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {   


            builder.Entity<Level>()
                .HasOne<LevelDetails>(l => l.LevelDetails)
                .WithOne(ld => ld.Level)
                .HasForeignKey<LevelDetails>(l => l.LevelDetailsId);

            builder.Entity<User>()
                .HasMany<Exercise>(u => u.Exercises)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);

            base.OnModelCreating(builder);
            new PrepDb(builder).Seed();
        }
    }
}