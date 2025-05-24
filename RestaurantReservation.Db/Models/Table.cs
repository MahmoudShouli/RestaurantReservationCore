namespace RestaurantReservation.Db.Models;

public class Table
{
    public Table()
    {
        Reservations = new List<Reservation>();
    }
    public int TableId { get; set; }
    public int Capacity { get; set; }   
    public int RestaurantId { get; set; }
    List<Reservation> Reservations { get; set; } 
}