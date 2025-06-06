﻿namespace RestaurantReservation.Db.Models;

public class MenuItem
{
    public MenuItem()
    {
        OrderItems = new List<OrderItem>();
    }
    public int ItemId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}