using FluentValidation;

namespace FoodStore.Application.TransactionOperations.Commands.DeleteTransaction
{
    public class DeleteTransactionCommandValidator : AbstractValidator<DeleteTransactionCommand>
    {
        public DeleteTransactionCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty().GreaterThan(0);
        }
    }
}
