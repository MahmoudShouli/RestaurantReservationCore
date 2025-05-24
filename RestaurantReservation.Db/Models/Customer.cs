namespace RestaurantReservation.Db.Models;

public class Customer
{
    public Customer()
    {
        Reservations = new List<Reservation>();
    }
    public int CustomerId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public List<Reservation> Reservations { get; set; }
}