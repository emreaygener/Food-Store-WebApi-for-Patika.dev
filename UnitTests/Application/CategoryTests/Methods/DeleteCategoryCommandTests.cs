using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.TestSetup;
using FoodApi.DbOperations;
using FoodApi.Application.CategoryOperations.Commands.DeleteCategory;

namespace UnitTests.Application.CategoryTests.Methods
{
    public class DeleteCategoryCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly FoodStoreDbContext _context;
        private readonly IMapper _mapper;
        public DeleteCategoryCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenInputGivenRefersToAnEmpthyReference_InvalidOperationException_ShouldBeReturned()
        {
            // Arrange
            DeleteCategoryCommand command = new(_context);
            command.Id = _context.Categories.OrderBy(x => x.Id).Last().Id + 1;
            // Act & Assertion
            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Given id is not related to any category!");
        }
        [Fact]
        public void WhenEreasedCategoryIdIsGıven_InvalidOperationException_ShouldBeReturned()
        {
            // Arrange
            DeleteCategoryCommand command = new(_context);
            command.Id = _context.Categories.OrderBy(x => x.Id).Last().Id;
            command.Handle();
            // Act & Assertion
            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Given id is not related to any category!");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Category_ShouldBeDeleted()
        {
            // Arrange
            DeleteCategoryCommand command = new(_context);
            command.Id = _context.Categories.OrderBy(x => x.Id).First().Id;
            // Act 
            FluentActions.Invoking(() => command.Handle()).Invoke();
            // Assert
            var food = _context.Categories.SingleOrDefault(food => food.Id == command.Id);
            food.Should().BeNull();
        }
    }
}
