using AutoMapper;
using FoodApi.DbOperations;
using static FoodApi.Common.ViewModels;

namespace FoodApi.Application.FoodOperations.Commands.UpdateFood
{
    public class UpdateFoodCommand
    {
        public CreateFoodViewModel Model { get; set; }
        public int Id { get; set; }
        private readonly IFoodStoreDbContext _context;
        public UpdateFoodCommand(IFoodStoreDbContext context, IMapper mapper)
        {
            _context = context;
        }
        public void Handle()
        {
            var food = _context.Foods.SingleOrDefault(x => x.Id == this.Id);
            if (food == null) { throw new InvalidOperationException("Id given is not related to any food!"); }
            food.Name = Model.Name == default || Model.Name == "string" ? food.Name : Model.Name;
            food.Details = Model.Details == default || Model.Details == "string" ? food.Details : Model.Details;
            food.Price = Model.Price == default || Model.Price == 0 ? food.Price : Model.Price;
            food.StockAmount = Model.StockAmount == default || Model.StockAmount == 0 ? food.StockAmount : food.StockAmount;
            food.CategoryId = Model.CategoryId == default || Model.CategoryId == 0 ? food.CategoryId : Model.CategoryId;
            _context.SaveChanges();
        }
    }
}
