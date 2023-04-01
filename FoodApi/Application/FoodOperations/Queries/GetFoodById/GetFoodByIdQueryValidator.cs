using FluentValidation;

namespace FoodApi.Application.FoodOperations.Queries.GetFoodById
{
    public class GetFoodByIdQueryValidator:AbstractValidator<GetFoodByIdQuery>
    {
        public GetFoodByIdQueryValidator() 
        {
            RuleFor(x=>x.Id).NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}
