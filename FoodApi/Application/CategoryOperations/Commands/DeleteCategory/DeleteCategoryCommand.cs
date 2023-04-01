using FoodApi.DbOperations;

namespace FoodApi.Application.CategoryOperations.Commands.DeleteCategory
{
    public class DeleteCategoryCommand
    {
        public int Id { get; set; }
        private readonly IFoodStoreDbContext _context;
        public DeleteCategoryCommand(IFoodStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var category = _context.Categories.FirstOrDefault(x=>x.Id==this.Id);
            if (category == null)
                throw new InvalidOperationException("Given id is not related to any category!");
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
