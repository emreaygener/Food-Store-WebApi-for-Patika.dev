using FluentAssertions;
using FoodApi.Application.FoodOperations.Commands.DeleteFood;
using FoodApi.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.TestSetup;

namespace UnitTests.Application.FoodTests.Validators
{
    public class DeleteFoodCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        private readonly FoodStoreDbContext _context;
        public DeleteFoodCommandValidatorTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidInputIsGiven_Validator_ShouldReturnErrors(int id)
        {
            // Arrange
            DeleteFoodCommand command = new(null,null);
            command.Id = id;
            // Act
            DeleteFoodCommandValidator validator = new();
            var result = validator.Validate(command);
            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenValidInputIsGiven_Validator_ShouldNotReturnErrors()
        {
            // Arrange
            DeleteFoodCommand command = new(null,null);
            command.Id = _context.Foods.First().Id;
            // Act
            DeleteFoodCommandValidator validator = new();
            var result = validator.Validate(command);
            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
