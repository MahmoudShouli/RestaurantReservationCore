namespace RestaurantReservation.Db.Models;

public class Reservation
{
    public Reservation()
    {
        Orders = new List<Order>();
    }
    public int ReservationId { get; set; }
    public DateTime ReservationDate { get; set; }
    public int PartySize { get; set; }
    public int CustomerId { get; set; }
    public int RestaurantId { get; set; }
    public int TableId { get; set; }
    public List<Order> Orders { get; set; } 
}