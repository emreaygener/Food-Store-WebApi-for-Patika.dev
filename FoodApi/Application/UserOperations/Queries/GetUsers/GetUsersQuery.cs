using AutoMapper;
using FoodApi.DbOperations;
using FoodApi.Entities;
using static FoodApi.Common.ViewModels;

namespace FoodApi.Application.UserOperations.Queries.GetUsers
{
    public class GetUsersQuery
    {
        private readonly IFoodStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetUsersQuery(IFoodStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<UserViewModel>Handle()
        {
            var users = _context.Users.OrderBy(x=>x.Id).ToList<User>();
            return _mapper.Map<List<UserViewModel>>(users);
        }
    }
}
