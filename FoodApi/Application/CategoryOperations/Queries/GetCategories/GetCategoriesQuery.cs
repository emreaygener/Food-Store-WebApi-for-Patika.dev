using AutoMapper;
using FoodApi.DbOperations;
using FoodApi.Entities;
using Microsoft.EntityFrameworkCore;
using static FoodApi.Common.ViewModels;

namespace FoodApi.Application.CategoryOperations.Queries.GetCategories
{
    public class GetCategoriesQuery
    {
        private readonly IFoodStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetCategoriesQuery(IFoodStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<CategoryViewModel>Handle()
        {
            var categories = _context.Categories.AsNoTracking().OrderBy(x=>x.Id).ToList<Category>();
            return _mapper.Map<List<CategoryViewModel>>(categories);
        }
    }
}
