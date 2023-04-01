using AutoMapper;
using FoodApi.DbOperations;
using FoodApi.Entities;
using static FoodApi.Common.ViewModels;

namespace FoodApi.Application.UserOperations.Commands.CreateUser
{
    public class CreateUserCommand
    {
        public CreateUserViewModel Model { get; set; }
        private readonly IFoodStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateUserCommand(IFoodStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == Model.Email);
            if (user is not null) { throw new InvalidOperationException("Email already linked to an account!"); }
            user = _mapper.Map<User>(Model);
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
