using AutoMapper;
using FoodApi.DbOperations;

namespace FoodApi.Application.FoodOperations.Commands.DeleteFood
{
    public class DeleteFoodCommand
    {
        public int Id { get; set; }
        private readonly IFoodStoreDbContext _context;
        public DeleteFoodCommand(IFoodStoreDbContext context, IMapper mapper)
        {
            _context = context;
        }
        public void Handle()
        {
            var food = _context.Foods.SingleOrDefault(f => f.Id == this.Id);
            if(food == null) { throw new InvalidOperationException("The id given is not related to any food!"); }
            _context.Foods.Remove(food);
            _context.SaveChanges();
        }
    }
}
