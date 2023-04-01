using FoodApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FoodStoreDbContext(serviceProvider.GetService<DbContextOptions<FoodStoreDbContext>>()))
            {
                if (context.Foods.Any())
                    return;
                // Create new genres and add to context
                context.Categories.AddRange(new Category { CategoryName = "SciFi" }, new Category { CategoryName = "Comedy" }, new Category { CategoryName = "Adventure" });

                // Create new users
                var user1 = new User { Name = "Emre", Surname = "Aygener", Email = "emre.aygener@gmail.com", Password = "123456" };
                var user2 = new User { Name = "Test", Surname = "Test", Email = "Test@gmail.com", Password = "123456" };

                // Create new Transactions
                var transaction1 = new Transaction { FoodId = 1, UserId = 1 };
                var transaction2 = new Transaction { FoodId = 2, UserId = 2 };

                // Create new foods
                var food1 = new Food
                {
                    Name = "Food 1",
                    Price = 10,
                    StockAmount = 5,
                    Details = "details",
                    CategoryId = 1
                };

                var food2 = new Food
                {
                    Name = "Food 2",
                    Price = 15,
                    StockAmount = 3,
                    Details="detailss",
                    CategoryId = 2
                };

                var food3 = new Food
                {
                    Name = "Food 3",
                    Price = 20,
                    StockAmount = 2,
                    Details="detailsss",
                    CategoryId = 3
                };

                // Add foods to the context
                context.Foods.AddRange(food1, food2, food3);

                context.Transactions.Add(transaction1);
                context.Transactions.Add(transaction2);
                context.Users.Add(user1);
                context.Users.Add(user2);

                // Save changes to the database
                context.SaveChanges();
            }
        }
    }
}
