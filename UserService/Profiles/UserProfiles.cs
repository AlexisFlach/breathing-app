using AutoMapper;
using UserService.Dtos;
using UserService.Dtos.RabbitMQ;
using UserService.Dtos.Requests;
using UserService.Models;

namespace UserService.Profiles
{
    public class ExercisesProfile : Profile
    {
        public ExercisesProfile()
        {
            CreateMap<UserPublishedDto, User>();
            CreateMap<UserRegisterDto, UserPublishedDto>();
            CreateMap<UserReadDto, UserRegisterDto>();
            CreateMap<UserRegisterDto, UserReadDto>();
        }         
    }
}