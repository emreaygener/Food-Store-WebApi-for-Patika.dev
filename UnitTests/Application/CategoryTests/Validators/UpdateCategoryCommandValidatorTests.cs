using FluentAssertions;
using FoodApi.Application.CategoryOperations.Commands.UpdateCategory;
using UnitTests.TestSetup;

namespace UnitTests.Application.CategoryTests.Validators
{
    public class UpdateCategoryCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0, "title")]
        [InlineData(1, "")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnError(int id, string title)
        {
            // Arrange
            UpdateCategoryCommand command = new(null);
            command.Model = new() { CategoryName = title };
            command.Id = id;
            // Act
            UpdateCategoryCommandValidator validator = new();
            var result = validator.Validate(command);
            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotReturnError()
        {
            // Arrange
            UpdateCategoryCommand command = new(null);
            command.Id = 1;
            command.Model = new() { CategoryName = "title" };
            // Act
            UpdateCategoryCommandValidator validator = new();
            var result = validator.Validate(command);
            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
