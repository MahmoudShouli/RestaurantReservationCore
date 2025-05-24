namespace RestaurantReservation.Db.Models;

public class MenuItem
{
    public MenuItem()
    {
        Orders = new List<Order>();
    }
    public int ItemId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public int RestaurantId { get; set; }
    public List<Order> Orders { get; set; }
}