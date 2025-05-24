using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Data;

public class RestaurantReservationDbContext : DbContext
{
    public RestaurantReservationDbContext(DbContextOptions<RestaurantReservationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Table> Tables { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<MenuItem>()
            .HasKey(mi => new { mi.ItemId });
        
        // To prevent multiple cascade paths issue
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Customer)
            .WithMany(c => c.Reservations)
            .HasForeignKey(r => r.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Restaurant)
            .WithMany(rest => rest.Reservations)
            .HasForeignKey(r => r.RestaurantId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Table)
            .WithMany(t => t.Reservations)
            .HasForeignKey(r => r.TableId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.MenuItem)
            .WithMany(mi =>mi.OrderItems)
            .HasForeignKey(oi => oi.ItemId)
            .OnDelete(DeleteBehavior.NoAction);
        
        // Decimal types
        modelBuilder.Entity<Order>()
            .Property(o => o.TotalAmount)
            .HasColumnType("decimal(18,2)");
        
        modelBuilder.Entity<MenuItem>()
            .Property(mi => mi.Price)
            .HasColumnType("decimal(18,2)");
        
        SeedTables(modelBuilder);
    }

    private void SeedTables(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Restaurant>().HasData(
            new { RestaurantId = 1, Name = "Ocean Grill", Address = "Beach Rd", PhoneNumber = "123-1111", OpeningHours = "9AM - 11PM" },
            new { RestaurantId = 2, Name = "Mountain Dine", Address = "Hilltop Ave", PhoneNumber = "123-2222", OpeningHours = "10AM - 10PM" },
            new { RestaurantId = 3, Name = "City Bites", Address = "Main St", PhoneNumber = "123-3333", OpeningHours = "8AM - 9PM" },
            new { RestaurantId = 4, Name = "Green Garden", Address = "Park Lane", PhoneNumber = "123-4444", OpeningHours = "11AM - 8PM" },
            new { RestaurantId = 5, Name = "Sunset Eats", Address = "Bay Blvd", PhoneNumber = "123-5555", OpeningHours = "12PM - 12AM" }
        );

        modelBuilder.Entity<Customer>().HasData(
            new { CustomerId = 1, FirstName = "Alice", LastName = "Jones", Email = "alice@example.com", PhoneNumber = "111-2222" },
            new { CustomerId = 2, FirstName = "Bob", LastName = "Smith", Email = "bob@example.com", PhoneNumber = "222-3333" },
            new { CustomerId = 3, FirstName = "Charlie", LastName = "Brown", Email = "charlie@example.com", PhoneNumber = "333-4444" },
            new { CustomerId = 4, FirstName = "Diana", LastName = "Prince", Email = "diana@example.com", PhoneNumber = "444-5555" },
            new { CustomerId = 5, FirstName = "Evan", LastName = "Stone", Email = "evan@example.com", PhoneNumber = "555-6666" }
        );

        modelBuilder.Entity<Table>().HasData(
            new { TableId = 1, Capacity = 4, RestaurantId = 1 },
            new { TableId = 2, Capacity = 2, RestaurantId = 1 },
            new { TableId = 3, Capacity = 6, RestaurantId = 2 },
            new { TableId = 4, Capacity = 4, RestaurantId = 3 },
            new { TableId = 5, Capacity = 8, RestaurantId = 3 }
        );

        modelBuilder.Entity<Employee>().HasData(
            new { EmployeeId = 1, FirstName = "Tom", LastName = "Cook", Position = "Chef", RestaurantId = 1 },
            new { EmployeeId = 2, FirstName = "Sara", LastName = "Lee", Position = "Waiter", RestaurantId = 1 },
            new { EmployeeId = 3, FirstName = "John", LastName = "Wick", Position = "Manager", RestaurantId = 2 },
            new { EmployeeId = 4, FirstName = "Emily", LastName = "Blunt", Position = "Waiter", RestaurantId = 3 },
            new { EmployeeId = 5, FirstName = "Robert", LastName = "Downey", Position = "Chef", RestaurantId = 4 }
        );

        modelBuilder.Entity<MenuItem>().HasData(
            new { ItemId = 1, Name = "Pizza", Description = "Cheesy delight", Price = 12.99m, RestaurantId = 1 },
            new { ItemId = 2, Name = "Burger", Description = "Beef burger", Price = 9.49m, RestaurantId = 1 },
            new { ItemId = 3, Name = "Pasta", Description = "Creamy Alfredo", Price = 11.00m, RestaurantId = 2 },
            new { ItemId = 4, Name = "Salad", Description = "Fresh greens", Price = 7.50m, RestaurantId = 3 },
            new { ItemId = 5, Name = "Sushi", Description = "Salmon roll", Price = 14.25m, RestaurantId = 3 }
        );

        modelBuilder.Entity<Reservation>().HasData(
            new { ReservationId = 1, ReservationDate = new DateTime(2025, 6, 1), PartySize = 2, CustomerId = 1, RestaurantId = 1, TableId = 1 },
            new { ReservationId = 2, ReservationDate = new DateTime(2025, 6, 2), PartySize = 3, CustomerId = 2, RestaurantId = 1, TableId = 2 },
            new { ReservationId = 3, ReservationDate = new DateTime(2025, 6, 3), PartySize = 4, CustomerId = 3, RestaurantId = 2, TableId = 3 },
            new { ReservationId = 4, ReservationDate = new DateTime(2025, 6, 4), PartySize = 2, CustomerId = 4, RestaurantId = 3, TableId = 4 },
            new { ReservationId = 5, ReservationDate = new DateTime(2025, 6, 5), PartySize = 1, CustomerId = 5, RestaurantId = 3, TableId = 5 }
        );

        modelBuilder.Entity<Order>().HasData(
            new { OrderId = 1, OrderDate = new DateTime(2025, 6, 1), TotalAmount = 25.98m, ReservationId = 1, EmployeeId = 1 },
            new { OrderId = 2, OrderDate = new DateTime(2025, 6, 2), TotalAmount = 9.49m, ReservationId = 2, EmployeeId = 2 },
            new { OrderId = 3, OrderDate = new DateTime(2025, 6, 3), TotalAmount = 11.00m, ReservationId = 3, EmployeeId = 3 },
            new { OrderId = 4, OrderDate = new DateTime(2025, 6, 4), TotalAmount = 22.50m, ReservationId = 4, EmployeeId = 4 },
            new { OrderId = 5, OrderDate = new DateTime(2025, 6, 5), TotalAmount = 28.50m, ReservationId = 5, EmployeeId = 5 }
        );
        
        modelBuilder.Entity<OrderItem>().HasData(
            new { OrderItemId = 1, Quantity = 2, OrderId = 1, ItemId = 1 },
            new { OrderItemId = 2, Quantity = 1, OrderId = 2, ItemId = 2 },
            new { OrderItemId = 3, Quantity = 1, OrderId = 3, ItemId = 3 },
            new { OrderItemId = 4, Quantity = 3, OrderId = 4, ItemId = 4 },
            new { OrderItemId = 5, Quantity = 2, OrderId = 5, ItemId = 5 }
        );
    }
}