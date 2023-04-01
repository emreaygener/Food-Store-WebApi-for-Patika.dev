using FoodApi.DbOperations;
using static FoodApi.Common.ViewModels;

namespace FoodApi.Application.UserOperations.Commands.UpdateUser
{
    public class UpdateUserCommand
    {
        public string Email { get; set; }
        public CreateUserViewModel Model { get; set; }
        private readonly IFoodStoreDbContext _context;

        public UpdateUserCommand(IFoodStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == Email);
            user.Name = Model.Name == default || Model.Name == "string" ? user.Name : Model.Name;
            user.Surname = Model.Surname == default || Model.Surname == "string" ? user.Surname : Model.Surname;
            user.Email = Model.Email == default || Model.Email == "string" ? user.Email : Model.Email;
            user.Password = Model.Password == default || Model.Password == "string" ? user.Password : Model.Password;
            _context.SaveChanges();
        }
    }
}
