using AutoMapper;
using FluentAssertions;
using FoodApi.Application.FoodOperations.Commands.CreateFood;
using FoodApi.DbOperations;
using FoodApi.Entities;
using UnitTests.TestSetup;
using static FoodApi.Common.ViewModels;

namespace UnitTests.Application.FoodTests.Methods
{
    public class CreateFoodCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly FoodStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateFoodCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistsFoodTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var food = new Food() { Name = "Test", Price = 10, StockAmount = 5, CategoryId = 1, Details = "details" };
            _context.Foods.Add(food);
            _context.SaveChanges();

            CreateFoodCommand command = new(_context, _mapper);
            command.Model = new() { Name = "Test" };

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Food is already at the list!");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Food_ShouldBeCreated()
        {
            //Arrange
            CreateFoodCommand command = new(_context, _mapper);
            CreateFoodViewModel model = new() { Name = "Hobbit", Price = 10, StockAmount = 5, CategoryId = 1, Details = "details" };
            command.Model = model;
            //Act
            FluentActions.Invoking(() => command.Handle()).Invoke();
            //Assert
            var food = _context.Foods.SingleOrDefault(food => food.Name == model.Name);
            food.Should().NotBeNull();
            food.Price.Should().Be(model.Price);
            food.StockAmount.Should().Be(model.StockAmount);
            food.CategoryId.Should().Be(model.CategoryId);
            food.Details.Should().Be(model.Details);

        }
    }
}
