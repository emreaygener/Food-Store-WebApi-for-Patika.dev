using FluentAssertions;
using FoodApi.Application.CategoryOperations.Commands.CreateCategory;
using UnitTests.TestSetup;

namespace UnitTests.Application.CategoryTests.Validators
{
    public class CreateCategoryCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        //[InlineData("title", 10, "2002-01-01", 10, 1, 1, 1, 3)]
        [InlineData("")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnError(string title)
        {
            // Arrange
            CreateCategoryCommand command = new(null);
            command.Model = new() { CategoryName = title};
            // Act
            CreateCategoryCommandValidator validator = new();
            var result = validator.Validate(command);
            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotReturnError()
        {
            // Arrange
            CreateCategoryCommand command = new(null);
            command.Model = new() { CategoryName = "title" };
            // Act
            CreateCategoryCommandValidator validator = new();
            var result = validator.Validate(command);
            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
