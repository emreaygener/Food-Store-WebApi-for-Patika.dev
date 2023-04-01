using AutoMapper;
using Microsoft.EntityFrameworkCore;
using FoodApi.DbOperations;
using static FoodApi.Common.ViewModels;

namespace FoodStore.Application.TransactionOperations.Queries.GetTransactions
{
    public class GetTransactionsQuery
    {
        private readonly IFoodStoreDbContext _context;
        private readonly IMapper _mapper;
        public string Email { get; set; }
        public GetTransactionsQuery(IFoodStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<DetailedTransactionViewModel> Handle()
        {
            var transactions = _context.Transactions
                                          .AsNoTracking()
                                              .Include(x=>x.User)
                                                  .Include(x=>x.Food)
                                                      .Where(x=>x.User.Email==Email)
                                                          .OrderBy(x => x.TransactionId)
                                                              .ToList();
            var vm = _mapper.Map<List<DetailedTransactionViewModel>>(transactions);
            return (vm);
        }
    }
}
