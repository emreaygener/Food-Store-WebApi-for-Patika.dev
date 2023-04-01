using FluentValidation;

namespace FoodApi.Application.FoodOperations.Commands.UpdateFood
{
    public class UpdateFoodCommandValidator : AbstractValidator<UpdateFoodCommand>
    {
        public UpdateFoodCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(0);
            RuleFor(x => x.Model.Details).NotEmpty().MinimumLength(0);
            RuleFor(x => x.Model.Price).GreaterThanOrEqualTo(0);
            RuleFor(x=>x.Id).NotNull().GreaterThan(0);
            RuleFor(x=>x.Model.CategoryId).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x=>x.Model.StockAmount).NotNull().GreaterThanOrEqualTo(0);
        }
    }
}
