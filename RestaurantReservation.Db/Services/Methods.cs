using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Services;

public class Methods(RestaurantReservationDbContext context)
{
    public async Task<List<Employee>> ListManagers()
    {
        var managers = await context.Employees
            .Where(e => e.Position == "Manager")
            .ToListAsync();
        return managers;
    }

    public async Task<List<Reservation>> GetReservationsByCustomer(int customerId)
    {
        var customer = await context.Customers
            .Include(c => c.Reservations)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        
        return customer?.Reservations ?? new List<Reservation>();
    }

    public async Task ListOrdersAndMenuItems(int reservationId)
    {
        var reservation = await context.Reservations
            .Include(r => r.Orders)
            .ThenInclude(o => o.OrderItems)
            .ThenInclude(oi => oi.MenuItem)
            .FirstOrDefaultAsync(r => r.ReservationId == reservationId);

        foreach (var order in reservation.Orders)
        {
            foreach (var orderItem in order.OrderItems)
            {
                Console.WriteLine(order.OrderId + " " + orderItem.MenuItem.Name);
            }
        }
        
    }
    
}