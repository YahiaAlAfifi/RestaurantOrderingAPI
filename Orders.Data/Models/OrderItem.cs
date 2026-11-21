namespace Orders.Data.Models
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public int MealId { get; set; }
        public Meal Meal { get; set; } = null!;

        public int Quantity { get; set; }

        public OrderItem()
        {
            Quantity = 1;
        }
    }
}