using AutoMapper;
using FoodApi.DbOperations;
using static FoodApi.Common.ViewModels;

namespace FoodApi.Application.CategoryOperations.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery
    {
        public int Id { get; set; }
        private readonly IFoodStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetCategoryByIdQuery(IFoodStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public CategoryViewModel Handle()
        {
            var category  = _context.Categories.FirstOrDefault(x=>x.Id==this.Id);
            if (category == null)
                throw new InvalidOperationException("Wrong Id!");
            return _mapper.Map<CategoryViewModel>(category);
        }
    }
}
