using FluentAssertions;
using FoodApi.Application.FoodOperations.Commands.CreateFood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.TestSetup;

namespace UnitTests.Application.FoodTests.Validators
{
    public class CreateFoodCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        //[InlineData("title", 10, "2002-01-01", 10, 1, 1, 1, 3)]
        [InlineData("title", 10, "2002-01-01", 10, -1)]
        [InlineData("title", 10, "2002-01-01", -1, 1)]
        [InlineData("title", 10, "", 10, 1)]
        [InlineData("title", -1, "2002-01-01", 10, 1)]
        [InlineData("", 10, "2002-01-01", 10, 1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnError(string title, int price, string details, int stockAmount, int genreId)
        {
            // Arrange
            CreateFoodCommand command = new(null, null);
            command.Model = new() { Name = title, Price = price, StockAmount = stockAmount, Details = details, CategoryId = genreId};
            // Act
            CreateFoodCommandValidator validator = new();
            var result = validator.Validate(command);
            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotReturnError()
        {
            // Arrange
            CreateFoodCommand command = new(null, null);
            command.Model = new() { Name = "title", Price = 10, StockAmount = 10, Details = "details", CategoryId = 1 };
            // Act
            CreateFoodCommandValidator validator = new();
            var result = validator.Validate(command);
            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
