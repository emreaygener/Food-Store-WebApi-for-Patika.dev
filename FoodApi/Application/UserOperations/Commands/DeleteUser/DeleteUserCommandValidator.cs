using FluentValidation;

namespace FoodApi.Application.UserOperations.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
