using FoodApi.DbOperations;
using FoodApi.Entities;
using static FoodApi.Common.ViewModels;

namespace FoodApi.Application.CategoryOperations.Commands.CreateCategory
{
    public class CreateCategoryCommand
    {
        public CategoryViewModel Model { get; set; }
        private readonly IFoodStoreDbContext _context;
        public CreateCategoryCommand(IFoodStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var category = _context.Categories.FirstOrDefault(x => x.CategoryName == Model.CategoryName);
            if (category is not null)
                throw new InvalidOperationException("Category already available!");
            category = new Category() { CategoryName = Model.CategoryName };
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
}
