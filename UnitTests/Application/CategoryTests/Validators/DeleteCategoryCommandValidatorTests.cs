using FluentAssertions;
using FoodApi.Application.CategoryOperations.Commands.DeleteCategory;
using FoodApi.DbOperations;
using UnitTests.TestSetup;

namespace UnitTests.Application.CategoryTests.Validators
{
    public class DeleteCategoryCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        private readonly FoodStoreDbContext _context;
        public DeleteCategoryCommandValidatorTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidInputIsGiven_Validator_ShouldReturnErrors(int id)
        {
            // Arrange
            DeleteCategoryCommand command = new(null);
            command.Id = id;
            // Act
            DeleteCategoryCommandValidator validator = new();
            var result = validator.Validate(command);
            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenValidInputIsGiven_Validator_ShouldNotReturnErrors()
        {
            // Arrange
            DeleteCategoryCommand command = new(null);
            command.Id = _context.Categories.First().Id;
            // Act
            DeleteCategoryCommandValidator validator = new();
            var result = validator.Validate(command);
            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
