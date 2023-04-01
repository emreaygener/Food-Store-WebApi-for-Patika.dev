using FluentAssertions;
using FoodApi.Application.CategoryOperations.Queries.GetCategoryById;
using UnitTests.TestSetup;

namespace UnitTests.Application.CategoryTests.Validators
{
    public class GetCategoryByIdQueryValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidIdIsGiven_Validator_ShouldThrowException()
        {
            GetCategoryByIdQuery query = new(null, null);
            query.Id = 0;
            var validator = new GetCategoryByIdQueryValidator();
            validator.Validate(query);
            FluentActions.Invoking(() => query.Handle()).Should().Throw<Exception>();
        }
    }
}
