using AutoMapper;
using ExerciseService.Dtos;
using ExerciseService.Models;

namespace ExerciseService.Profiles
{
    public class ExercisesProfile : Profile
    {
        public ExercisesProfile()
        {
            CreateMap<UserPublishedDto, User>();
            CreateMap<ExerciseReadDto, Exercise>();
            CreateMap<ExerciseCreateDto, Exercise>();
            CreateMap<Exercise, ExerciseReadDto>();
        }
    }
}