using AutoMapper;
using Microsoft.EntityFrameworkCore;
using FoodApi.DbOperations;
using static FoodApi.Common.ViewModels;

namespace FoodStore.Application.TransactionOperations.Queries.GetTransactionById
{
    public class GetTransactionByIdQuery
    {
        public int TransactionId { get; set; }
        private readonly IFoodStoreDbContext _context;
        private readonly IMapper _mapper;
        public string Email { get; set; }
        public GetTransactionByIdQuery(IFoodStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public DetailedTransactionViewModel Handle()
        {
            var transaction = _context.Transactions
                      .AsNoTracking()
                          .Include(x => x.User).Include(x => x.Food)
                              .Where(x => x.User.Email == Email)
                                   .SingleOrDefault(x=>x.TransactionId== TransactionId);
            if (transaction== null)
            { throw new InvalidOperationException("Girdiğiniz id ile bir satın alım eşleşmemektedir."); }

            return _mapper.Map<DetailedTransactionViewModel>(transaction);
        }
    }
}
