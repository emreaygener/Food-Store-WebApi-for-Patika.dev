

using AutoMapper;
using FluentAssertions;
using FoodApi.Application.FoodOperations.Commands.UpdateFood;
using FoodApi.DbOperations;
using Microsoft.EntityFrameworkCore;
using UnitTests.TestSetup;
using static FoodApi.Common.ViewModels;

namespace UnitTests.Application.FoodTests.Methods
{
    public class UpdateFoodCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly FoodStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateFoodCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenInvalidFoodIdIsGiven_InvalidOperationException_ShouldBeReturned()
        {
            // Arrange
            UpdateFoodCommand command = new UpdateFoodCommand(_context, _mapper);
            command.Id = _context.Foods.Include(m => m.Category).OrderBy(x => x.Id).Last().Id + 1;
            // Act & Assert
            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Id given is not related to any food!");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Food_ShouldBeUpdated()
        {
            // Arrange
            UpdateFoodCommand command = new(_context, _mapper);
            command.Id = _context.Foods.First().Id;
            CreateFoodViewModel model = new() { Name = "Hobbit", Price = 10, StockAmount = 5, Details = "Details", CategoryId = 1 };
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
