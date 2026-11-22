using System.ComponentModel.DataAnnotations;

namespace Orders.Data.Models
{
    public class Order : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        public string CustomerId { get; set; } = null!;

        public User Customer { get; set; } = null!;

        public int ResturantId { get; set; }
        public Resturant Resturant { get; set; } = null!;

        public List<OrderItem> OrderItems { get; set; } = new();
    }
}