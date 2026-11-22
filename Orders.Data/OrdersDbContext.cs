using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Orders.Data.Models;

namespace Orders.API.Data
{
    public class OrdersDbContext : IdentityDbContext<User>
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OrderItem>()
                .HasKey(x => new { x.OrderId, x.MealId });

            builder.Entity<OrderItem>()
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>()
                .HasQueryFilter(x => !x.IsDelete);

            builder.Entity<User>()
                .Property(x => x.Latitude)
                .HasPrecision(9, 6);

            builder.Entity<User>()
                .Property(x => x.Longitude)
                .HasPrecision(9, 6);

            builder.Entity<Resturant>()
                .Property(x => x.Latitude)
                .HasPrecision(9, 6);

            builder.Entity<Resturant>()
                .Property(x => x.Longitude)
                .HasPrecision(9, 6);
        }

        public DbSet<Resturant> Resturants { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Meal> Meals { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
    }
}
