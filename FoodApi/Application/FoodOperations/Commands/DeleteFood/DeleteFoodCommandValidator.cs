using FluentValidation;

namespace FoodApi.Application.FoodOperations.Commands.DeleteFood
{
    public class DeleteFoodCommandValidator:AbstractValidator<DeleteFoodCommand>
    {
        public DeleteFoodCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
