using AutoMapper;
using FoodApi.DbOperations;
using FoodStore.TokenOperations;
using FoodStore.TokenOperations.Models;
using static FoodApi.Common.ViewModels;

namespace FoodApi.Application.UserOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        public LoginViewModel Model { get; set; }
        private readonly IFoodStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public CreateTokenCommand(IFoodStoreDbContext context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }
        public Token Handle()
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            if (user is null) { throw new InvalidOperationException("Email or password is incorrect!"); }
            TokenHandler handler = new(_config);
            Token token = handler.CreateAccessToken(user);
            user.RefreshToken= token.RefreshToken;
            user.RefreshTokenExpireDate = token.ExpirationDate.AddMinutes(5);
            _context.SaveChanges();
            return token;
        }
    }
}
