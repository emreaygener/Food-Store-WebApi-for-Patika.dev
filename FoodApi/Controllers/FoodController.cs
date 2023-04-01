using AutoMapper;
using FluentValidation;
using FoodApi.Application.FoodOperations.Commands.CreateFood;
using FoodApi.Application.FoodOperations.Commands.DeleteFood;
using FoodApi.Application.FoodOperations.Commands.UpdateFood;
using FoodApi.Application.FoodOperations.Queries.GetFoodById;
using FoodApi.Application.FoodOperations.Queries.GetFoods;
using FoodApi.DbOperations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FoodApi.Common.ViewModels;

namespace FoodApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]s")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodStoreDbContext _context;
        private readonly IMapper _mapper;
        public FoodController(IFoodStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetFoods()
        {
            GetFoodsQuery query = new(_context,_mapper);
            return Ok(query.Handle());
        }
        [HttpGet("id")]
        public IActionResult GetFoodById([FromQuery]int id) 
        {
            GetFoodByIdQuery query= new(_context,_mapper);
            query.Id = id;
            GetFoodByIdQueryValidator validator = new();
            validator.ValidateAndThrow(query);
            return Ok(query.Handle());
        }
        [HttpPost]
        public IActionResult CreateFood([FromBody]CreateFoodViewModel model)
        {
            CreateFoodCommand command = new(_context, _mapper);
            command.Model=model;
            CreateFoodCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpDelete("id")]
        public IActionResult DeleteFood([FromQuery]int id) 
        {
            DeleteFoodCommand command = new(_context,_mapper);
            command.Id = id;
            DeleteFoodCommandValidator validator= new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPut("id")]
        public IActionResult UpdateFood([FromBody]CreateFoodViewModel model, int id)
        {
            UpdateFoodCommand command = new(_context,_mapper);
            command.Id = id;
            command.Model=model;
            UpdateFoodCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}