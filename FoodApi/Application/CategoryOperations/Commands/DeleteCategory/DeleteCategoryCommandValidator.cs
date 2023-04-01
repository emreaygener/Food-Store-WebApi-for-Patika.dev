using FluentValidation;

namespace FoodApi.Application.CategoryOperations.Commands.DeleteCategory
{
    public class DeleteCategoryCommandValidator:AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(z=>z.Id).NotEmpty().GreaterThan(0);
        }
    }
}
