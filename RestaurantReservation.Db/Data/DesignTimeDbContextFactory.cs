using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RestaurantReservation.Db.Data;

namespace RestaurantReservation.Db.Data;

public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<RestaurantReservationDbContext>
{
    public RestaurantReservationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RestaurantReservationDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=RestaurantReservationCore;Trusted_Connection=True;Encrypt=False;");

        return new RestaurantReservationDbContext(optionsBuilder.Options);
    }
}