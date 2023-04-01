using FluentAssertions;
using FoodApi.Application.FoodOperations.Commands.UpdateFood;
using UnitTests.TestSetup;

namespace UnitTests.Application.FoodTests.Validators
{
    public class UpdateFoodCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(1, "title", 10, "2002-01-01", 10, -1)]
        [InlineData(1, "title", 10, "2002-01-01", -1, 1)]
        [InlineData(1, "title", 10, "", 10, 1)]
        [InlineData(1, "title", -1, "2002-01-01", 10, 1)]
        [InlineData(1, "", 10, "2002-01-01", 10, 1)]
        [InlineData(-1, "title", 10, "2002-01-01", 10, 1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnError(int id, string title, int price, string details, int stockAmount, int categoryId)
        {
            // Arrange
            UpdateFoodCommand command = new(null, null);
            command.Model = new() { Name = title, Price = price, StockAmount = stockAmount, Details = details, CategoryId = categoryId };
            command.Id = id;
            // Act
            UpdateFoodCommandValidator validator = new();
            var result = validator.Validate(command);
            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotReturnError()
        {
            // Arrange
            UpdateFoodCommand command = new(null, null);
            command.Id = 1;
            command.Model = new() { Name = "title", Price = 10, StockAmount = 10, Details = "details", CategoryId = 1 };
            // Act
            UpdateFoodCommandValidator validator = new();
            var result = validator.Validate(command);
            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
