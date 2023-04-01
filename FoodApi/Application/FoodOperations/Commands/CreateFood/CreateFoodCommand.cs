using AutoMapper;
using FoodApi.DbOperations;
using FoodApi.Entities;
using static FoodApi.Common.ViewModels;

namespace FoodApi.Application.FoodOperations.Commands.CreateFood
{
    public class CreateFoodCommand
    {
        public CreateFoodViewModel Model { get; set; }
        private readonly IFoodStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateFoodCommand(IFoodStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var food=_context.Foods.FirstOrDefault(x=>x.Name==Model.Name);
            if (food!=null) { throw new InvalidOperationException("Food is already at the list!"); }
            food = _mapper.Map<Food>(Model);
            _context.Foods.Add(food);
            _context.SaveChanges();
        }
    }
}
