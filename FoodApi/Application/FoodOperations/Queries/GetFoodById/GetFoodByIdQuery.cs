using AutoMapper;
using FoodApi.DbOperations;
using Microsoft.EntityFrameworkCore;
using static FoodApi.Common.ViewModels;

namespace FoodApi.Application.FoodOperations.Queries.GetFoodById
{
    public class GetFoodByIdQuery
    {
        public int Id { get; set; }
        private readonly IFoodStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetFoodByIdQuery(IFoodStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public BasicFoodViewModel Handle()
        {
            var food = _context.Foods.AsNoTracking().Include(x => x.Category).SingleOrDefault(x => x.Id == this.Id);
            if (food == null) { throw new InvalidOperationException("Id given is NOT related to any food!"); }
            return _mapper.Map<BasicFoodViewModel>(food);
        }
    }
}
