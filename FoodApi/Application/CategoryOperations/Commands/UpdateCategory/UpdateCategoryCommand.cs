using FoodApi.DbOperations;
using static FoodApi.Common.ViewModels;

namespace FoodApi.Application.CategoryOperations.Commands.UpdateCategory
{
    public class UpdateCategoryCommand
    {
        public CategoryViewModel Model { get; set; }
        public int Id { get; set; }
        private readonly IFoodStoreDbContext _context;
        public UpdateCategoryCommand(IFoodStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == this.Id);
            if (category == null)
                throw new InvalidOperationException("Id given is not related to any category!");
            category.CategoryName=Model.CategoryName;
            _context.SaveChanges();
        }
    }
}
