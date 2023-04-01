using AutoMapper;
using FluentAssertions;
using FoodApi.Application.FoodOperations.Commands.DeleteFood;
using FoodApi.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.TestSetup;

namespace UnitTests.Application.FoodTests.Methods
{
    public class DeleteFoodCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly FoodStoreDbContext _context;
        private readonly IMapper _mapper;
        public DeleteFoodCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenInputGivenRefersToAnEmpthyReference_InvalidOperationException_ShouldBeReturned()
        {
            // Arrange
            DeleteFoodCommand command = new(_context, _mapper);
            command.Id = _context.Foods.OrderBy(x => x.Id).Last().Id + 1;
            // Act & Assertion
            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("The id given is not related to any food!");
        }
        [Fact]
        public void WhenEreasedFoodIdIsGıven_InvalidOperationException_ShouldBeReturned()
        {
            // Arrange
            DeleteFoodCommand command = new(_context, _mapper);
            command.Id = _context.Foods.OrderBy(x => x.Id).Last().Id;
            command.Handle();
            // Act & Assertion
            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("The id given is not related to any food!");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Food_ShouldBeDeleted()
        {
            // Arrange
            DeleteFoodCommand command = new(_context, _mapper);
            command.Id = _context.Foods.OrderBy(x => x.Id).First().Id;
            // Act 
            FluentActions.Invoking(() => command.Handle()).Invoke();
            // Assert
            var food = _context.Foods.SingleOrDefault(food => food.Id == command.Id);
            food.Should().BeNull();
        }
    }
}
