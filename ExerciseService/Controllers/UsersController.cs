using AutoMapper;
using ExerciseService.Dtos;
using ExerciseService.Models;
using ExerciseService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseService.Controllers
{
    [Route("api/e/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public UsersController(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetUsers()
        {   
            Console.WriteLine("Getting all users from Exercice Service");
            var userItems = _exerciseRepository.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
        }

    }
}