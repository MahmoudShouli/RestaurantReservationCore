﻿namespace RestaurantReservation.Db.Models;

public class OrderItem
{
    public int OrderItemId { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }
    public int ItemId { get; set; }
    public Order Order { get; set; }
    public MenuItem MenuItem { get; set; }
}