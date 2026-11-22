using System.ComponentModel.DataAnnotations;

namespace Orders.Data.Models
{
    public class Meal : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
        public string? Image { get; set; }
        public float Price { get; set; }
        public float? DiscountValue { get; set; }

        public int ResturantId { get; set; }
        public Resturant Resturant { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public List<OrderItem> Orders { get; set; } = new();
    }
}