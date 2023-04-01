using FoodApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodApi.DbOperations
{
    public interface IFoodStoreDbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        int SaveChanges();
    }
}
