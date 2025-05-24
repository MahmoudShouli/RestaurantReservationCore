namespace RestaurantReservation.Db.Models;

public class Employee
{
    public Employee()
    {
        Orders = new List<Order>();
    }
    public int EmployeeId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Position { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public List<Order> Orders { get; set; }
}