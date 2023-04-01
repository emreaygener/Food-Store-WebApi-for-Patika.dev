using FluentValidation;

namespace FoodApi.Application.CategoryOperations.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x=>x.Model.CategoryName).NotEmpty().MinimumLength(2);
        }
    }
}
