using System.ComponentModel.DataAnnotations.Schema;

namespace FoodApi.Entities
{
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
