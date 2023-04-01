using FoodApi.DbOperations;

namespace FoodApi.Application.UserOperations.Commands.DeleteUser
{
    public class DeleteUserCommand
    {
        public int Id { get; set; }
        private readonly IFoodStoreDbContext _context;
        public DeleteUserCommand(IFoodStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == Id);
            if (user == null) { throw new InvalidOperationException("Wrong User Id!"); }
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
