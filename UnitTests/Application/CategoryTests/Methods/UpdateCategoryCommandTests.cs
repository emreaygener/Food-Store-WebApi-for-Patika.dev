using AutoMapper;
using FluentAssertions;
using UnitTests.TestSetup;
using FoodApi.DbOperations;
using FoodApi.Application.CategoryOperations.Commands.UpdateCategory;
using Microsoft.EntityFrameworkCore;
using static FoodApi.Common.ViewModels;

namespace UnitTests.Application.CategoryTests.Methods
{
    public class UpdateCategoryCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly FoodStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateCategoryCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenInvalidCategoryIdIsGiven_InvalidOperationException_ShouldBeReturned()
        {
            // Arrange
            UpdateCategoryCommand command = new UpdateCategoryCommand(_context);
            command.Id = _context.Categories.OrderBy(x => x.Id).Last().Id + 1;
            // Act & Assert
            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Id given is not related to any category!");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Category_ShouldBeUpdated()
        {
            // Arrange
            UpdateCategoryCommand command = new(_context);
            command.Id = _context.Categories.First().Id;
            CategoryViewModel model = new() { CategoryName = "Hobbit" };
            command.Model = model;
            //Act
            FluentActions.Invoking(() => command.Handle()).Invoke();
            //Assert
            var food = _context.Categories.SingleOrDefault(food => food.CategoryName == model.CategoryName);
            food.Should().NotBeNull();

        }
    }
}
