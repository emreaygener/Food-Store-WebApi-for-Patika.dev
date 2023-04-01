using FluentValidation;

namespace FoodStore.Application.TransactionOperations.Queries.GetTransactionById
{
    public class GetTransactionByIdQueryValidator : AbstractValidator<GetTransactionByIdQuery>
    {
        public GetTransactionByIdQueryValidator() 
        { 
            RuleFor(query => query.TransactionId).GreaterThan(0).NotNull(); 
        }
    }
}
