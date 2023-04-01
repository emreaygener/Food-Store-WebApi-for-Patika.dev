using FluentValidation;

namespace FoodApi.Application.CategoryOperations.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryValidator:AbstractValidator<GetCategoryByIdQuery>
    {
        public GetCategoryByIdQueryValidator()
        {
            RuleFor(x=>x.Id).NotEmpty().GreaterThan(0);
        }
    }
}
