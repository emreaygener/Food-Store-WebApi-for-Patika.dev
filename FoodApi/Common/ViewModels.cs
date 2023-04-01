using FoodApi.Entities;

namespace FoodApi.Common
{
    public class ViewModels
    {
        public class BasicFoodViewModel
        {
            public string Name { get; set; }
            public float Price { get; set; }
            public int StockAmount { get; set; }
            public string Category { get; set; }
        }
        public class CreateFoodViewModel
        {
            public string Name { get; set; }
            public float Price { get; set; }
            public string Details { get; set; }
            public int StockAmount { get; set; }
            public int CategoryId { get; set; }
        }
        public class CreateUserViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
        public class CategoryViewModel
        {
            public string CategoryName { get; set; }
        }
        public class UserViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
        }
        public class PurchaseViewModel
        {
            public int UserId { get; set; }
            public int FoodId { get; set; }
        }
        public class DetailedTransactionViewModel
        {
            public int TransactionId { get; set; }
            public DateTime PurchaseDate { get; set; } = DateTime.Now;
            public string Price { get; set; }
            public int FoodId { get; set; }
            public string Food { get; set; }
            public int UserId { get; set; }
            public string User { get; set; }
        }
        public class LoginViewModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
