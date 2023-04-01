using AutoMapper;
using Microsoft.EntityFrameworkCore;
using FoodApi.DbOperations;
using FoodApi.Entities;
using static FoodApi.Common.ViewModels;

namespace FoodStore.Application.TransactionOperations.Commands.CreateTransaction
{
    public class CreateTransactionCommand
    {
        public string Email { get; set; }
        public PurchaseViewModel Model { get; set; }
        private readonly IFoodStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateTransactionCommand(IFoodStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var pvm = _mapper.Map<Transaction>(Model);
            if 
            (Email != _context.Transactions.Include(x => x.User).FirstOrDefault(x => x.UserId == pvm.UserId).User.Email)
            { throw new InvalidOperationException("Başka bir kullanıcının idsi ile işlem yapamazsınız!"); }
            _context.Transactions.Add(pvm);
            _context.SaveChanges();
        }
    }
}
