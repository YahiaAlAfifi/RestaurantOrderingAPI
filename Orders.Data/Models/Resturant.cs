using System.ComponentModel.DataAnnotations;

namespace Orders.Data.Models
{
    public class Resturant : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? LogoUrl { get; set; }

        [Required]
        public string Phone { get; set; } = null!;

        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? Address { get; set; }

        public List<Meal> Meals { get; set; } = new();
        public List<Order> Orders { get; set; } = new();
    }
}