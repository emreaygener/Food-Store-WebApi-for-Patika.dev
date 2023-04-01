using FluentAssertions;
using FoodApi.Application.FoodOperations.Queries.GetFoodById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.TestSetup;

namespace UnitTests.Application.FoodTests.Validators
{
    public class GetFoodByIdQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidIdIsGiven_Validator_ShouldThrowException()
        {
            GetFoodByIdQuery query = new(null, null);
            query.Id = 0;
            var validator = new GetFoodByIdQueryValidator();
            validator.Validate(query);
            FluentActions.Invoking(() => query.Handle()).Should().Throw<Exception>();
        }
    }
}
