using AutoMapper;
using ExerciseService.Dtos;
using ExerciseService.Models;
using ExerciseService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseService.Controllers
{
    [Route("api/e/users/{userId}/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseRepository _repo;
        private readonly IMapper _mapper;

        public ExercisesController(IExerciseRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetExericesForUser(int userId)
        {
            var exercises = _repo.GetExercisesForUser(userId);
            return Ok(_mapper.Map<IEnumerable<ExerciseReadDto>>(exercises));
        }

        [HttpGet("{id}", Name = "GetExerciseById")]
        public ActionResult GetExerciseById(int id)
        {
            var exercise = _repo.GetExerciseById(id);
            if (exercise != null)
            {
                return Ok(_mapper.Map<ExerciseReadDto>(exercise));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateExercise(int userId, ExerciseCreateDto exerciseCreateDto)
        {
            var exerciseModel = _mapper.Map<Exercise>(exerciseCreateDto);
            exerciseModel.UserId = userId;
            _repo.CreateExercise(exerciseModel);
            _repo.SaveChanges();

            var exerciseReadDto = _mapper.Map<ExerciseReadDto>(exerciseModel);

            return CreatedAtRoute(nameof(GetExerciseById), new { userId = userId, id = exerciseReadDto.Id }, exerciseReadDto);
        }
    }
}