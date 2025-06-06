﻿namespace RestaurantReservation.Db.Models;

public class Order
{
    public Order()
    {
        OrderItems = new List<OrderItem>();
    }
    public int OrderId { get; set; }    
    public DateTime OrderDate { get; set; }
    public required decimal TotalAmount { get; set; }
    public int ReservationId { get; set; }  
    public Reservation Reservation { get; set; }
    public int EmployeeId { get; set; } 
    public Employee Employee { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}