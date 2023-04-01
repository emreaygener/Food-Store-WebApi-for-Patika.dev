using AutoMapper;
using FoodApi.DbOperations;
using FoodApi.Entities;
using Microsoft.EntityFrameworkCore;
using static FoodApi.Common.ViewModels;

namespace FoodApi.Application.FoodOperations.Queries.GetFoods
{
    public class GetFoodsQuery
    {
        private readonly IFoodStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetFoodsQuery(IFoodStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<BasicFoodViewModel> Handle()
        {
            var foods = _context.Foods.AsNoTracking().Include(x=>x.Category).OrderBy(x=>x.Id).ToList<Food>();
            return _mapper.Map<List<BasicFoodViewModel>>(foods);
        }
    }
}
