using System.ComponentModel.DataAnnotations.Schema;

namespace FoodApi.Entities
{
    public class Food
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public float Price { get; set; }
        public int StockAmount { get; set; }

        //Relationships
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
