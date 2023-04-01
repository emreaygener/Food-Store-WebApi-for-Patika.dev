using FluentValidation;

namespace FoodApi.Application.CategoryOperations.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator:AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(x=>x.Model.CategoryName).NotEmpty().MinimumLength(2);
        }
    }
}
