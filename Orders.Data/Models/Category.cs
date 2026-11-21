using System.ComponentModel.DataAnnotations;

namespace Orders.Data.Models
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public List<Meal> Meals { get; set; } = new();
    }
}