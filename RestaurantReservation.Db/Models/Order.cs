namespace RestaurantReservation.Db.Models;

public class Order
{
    public Order()
    {
        OrderItems = new List<OrderItem>();
    }
    public int OrderId { get; set; }    
    public DateTime OrderDate { get; set; }
    public required decimal OrderPrice { get; set; }
    public int ReservationId { get; set; }  
    public int EmployeeId { get; set; } 
    public List<OrderItem> OrderItems { get; set; }
}