using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserService.Dtos;
using UserService.Dtos.RabbitMQ;
using UserService.Dtos.Requests;
using UserService.Models;
using UserService.RabbitMQ;
using UserService.Repositories;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IMessageBusClient _messageBusClient;
        private readonly IMapper _mapper;

        public AuthController(IAuthRepository authRepo, IMapper mapper, IMessageBusClient messageBusClient)
        {
            _repo = authRepo;
            _mapper = mapper;
            _messageBusClient = messageBusClient;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await _repo.Register(
                new User { Username = request.Username }, request.Password
            );
            if (!response.Success)
            {
                return BadRequest(response);
            }

            var UserReadDto = _mapper.Map<UserReadDto>(request);

            try {
                var userPublishedDto = _mapper.Map<UserPublishedDto>(request);
                userPublishedDto.Event = "User_Published";
                _messageBusClient.PublishNewUser(userPublishedDto);
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserReadDto> GetPlatformById(int id)
        {
            var platformItem = _repo.GetUserById(id);
            if (platformItem != null)
            {
                return Ok(_mapper.Map<UserReadDto>(platformItem));
            }

            return NotFound();
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto request)
        {
            var response = await _repo.Login(request.Username, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}