using AutoMapper;
using FluentValidation;
using FoodApi.Application.CategoryOperations.Commands.CreateCategory;
using FoodApi.Application.CategoryOperations.Commands.DeleteCategory;
using FoodApi.Application.CategoryOperations.Commands.UpdateCategory;
using FoodApi.Application.CategoryOperations.Queries.GetCategories;
using FoodApi.Application.CategoryOperations.Queries.GetCategoryById;
using FoodApi.DbOperations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FoodApi.Common.ViewModels;

namespace FoodApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]s")]
    public class CategoryController : ControllerBase
    {
        private readonly IFoodStoreDbContext _context;
        private readonly IMapper _mapper;
        public CategoryController(IFoodStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetCategories()
        {
            GetCategoriesQuery query = new(_context, _mapper);
            return Ok(query.Handle());
        }
        [HttpGet("id")]
        public IActionResult GetCategory([FromQuery]int id)
        {
            GetCategoryByIdQuery query= new(_context, _mapper);
            query.Id = id;
            return Ok(query.Handle());
        }
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryViewModel model)
        {
            CreateCategoryCommand command = new(_context);
            command.Model = model;
            CreateCategoryCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpDelete("id")]
        public IActionResult DeleteCategory([FromQuery] int id)
        {
            DeleteCategoryCommand command = new(_context);
            command.Id = id;
            DeleteCategoryCommandValidator vallidator = new();
            vallidator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPut("id")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryViewModel model)
        {
            UpdateCategoryCommand command = new(_context);
            command.Id = id;
            command.Model = model;
            UpdateCategoryCommandValidator vallidator = new();
            vallidator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
