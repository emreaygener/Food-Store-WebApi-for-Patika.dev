using AutoMapper;
using FluentValidation;
using FoodApi.Application.UserOperations.Commands.CreateToken;
using FoodApi.Application.UserOperations.Commands.CreateUser;
using FoodApi.Application.UserOperations.Commands.DeleteUser;
using FoodApi.Application.UserOperations.Commands.RefreshToken;
using FoodApi.Application.UserOperations.Commands.UpdateUser;
using FoodApi.Application.UserOperations.Queries.GetUsers;
using FoodApi.DbOperations;
using FoodStore.TokenOperations.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static FoodApi.Common.ViewModels;

namespace FoodApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class UserController:ControllerBase
    {
        private readonly IFoodStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public UserController(IFoodStoreDbContext context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            GetUsersQuery query = new(_context,_mapper);
            return Ok(query.Handle());
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody]CreateUserViewModel model)
        {
            CreateUserCommand command = new(_context, _mapper);
            command.Model=model;
            CreateUserCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] LoginViewModel login)
        {
            CreateTokenCommand command = new(_context, _mapper, _config);
            command.Model = login;
            var token = command.Handle();
            return Ok(token);
        }
        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new(_context, _config);
            command.RefreshToken = token;
            var resultToken = command.Handle();
            return resultToken;
        }
        [HttpDelete("id")]
        public IActionResult DeleteUser(int id)
        {
            DeleteUserCommand command = new(_context);
            command.Id = id;
            DeleteUserCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPut]
        [Authorize]
        public IActionResult UpdateUser([FromBody]CreateUserViewModel vm)
        {
            UpdateUserCommand command= new(_context);
            command.Model = vm;
            var email = HttpContext.User.Claims.FirstOrDefault().Value;
            command.Email = email;
            command.Handle();
            return Ok();
        }
    }
}
