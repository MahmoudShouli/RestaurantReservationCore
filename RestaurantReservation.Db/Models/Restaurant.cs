namespace RestaurantReservation.Db.Models;

public class Restaurant
{
    public Restaurant()
    {
        Employees = new List<Employee>();
        Tables = new List<Table>();
        Reservations = new List<Reservation>();
        MenuItems = new List<MenuItem>();
    }
    public int RestaurantId { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required string PhoneNumber { get; set; }
    public string? OpeningHours { get; set; }
    public List<Employee> Employees { get; set; }
    public List<Table> Tables { get; set; }
    public List<Reservation> Reservations { get; set; }
    public List<MenuItem> MenuItems { get; set; }
}