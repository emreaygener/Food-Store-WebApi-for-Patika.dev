using FoodApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodApi.DbOperations
{
    public class FoodStoreDbContext : DbContext, IFoodStoreDbContext
    {
        public FoodStoreDbContext(DbContextOptions<FoodStoreDbContext> options) : base(options) { }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

    }
}
