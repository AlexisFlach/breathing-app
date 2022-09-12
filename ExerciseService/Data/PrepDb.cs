using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ExerciseService.Models;

namespace ExerciseService.Data
{
    public class PrepDb
    {
        private readonly ModelBuilder _modelBuilder;

        public PrepDb(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {   

            _modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "John"
            },
                new User
                {
                    Id = 2,
                    Name = "Mary"
            },
                new User
                {
                    Id = 3,
                    Name = "Jane"
            }
            );
            _modelBuilder.Entity<LevelDetails>().HasData(
                 new LevelDetails()
                 {
                     LevelDetailsId = 1,
                     Inhale = 1000,
                     Exhale = 1000,
                     Duration = 10000
                 },
                    new LevelDetails()
                    {
                        LevelDetailsId = 2,
                        Inhale = 2000,
                        Exhale = 2000,
                        Duration = 20000
                    },
                    new LevelDetails()
                    {
                        LevelDetailsId = 3,
                        Inhale = 3000,
                        Exhale = 3000,
                        Duration = 30000
                    }
                );

            _modelBuilder.Entity<Level>().HasData(
                new Level()
                {
                    LevelId = 1,
                    Name = "Beginner",
                    LevelDetailsId = 1
                },
                    new Level()
                    {
                        LevelId = 2,
                        Name = "Intermediate",
                        LevelDetailsId = 2
                    },
                    new Level()
                    {
                        LevelId = 3,
                        Name = "Advanced",
                        LevelDetailsId = 3
                    }
            );
            _modelBuilder.Entity<Exercise>().HasData(
new Exercise()
{
    ExerciseId = 1,
    LevelId = 1,
    IsFinished = false,
    StartedAt = DateTime.UtcNow,
    UserId = 1
},
                    new Exercise()
                    {
                        ExerciseId = 2,
                        LevelId = 2,
                        IsFinished = false,
                        StartedAt = DateTime.UtcNow,
                        UserId = 1
                    },
                    new Exercise()
                    {
                        ExerciseId = 3,
                        LevelId = 3,
                        IsFinished = false,
                        StartedAt = DateTime.UtcNow,
                        UserId = 2
                    }
            );


        }
    }
}