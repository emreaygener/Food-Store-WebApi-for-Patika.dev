using FluentValidation;

namespace FoodApi.Application.FoodOperations.Commands.CreateFood
{
    public class CreateFoodCommandValidator:AbstractValidator<CreateFoodCommand>
    {
        public CreateFoodCommandValidator()
        {
            RuleFor(x=>x.Model.Name).NotEmpty().MinimumLength(0);
            RuleFor(x=>x.Model.Price).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x=>x.Model.Details).NotEmpty().MinimumLength(0);
            RuleFor(x => x.Model.CategoryId).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(x => x.Model.StockAmount).NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}
