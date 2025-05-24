using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = config.GetConnectionString("DefaultConnection");

var options = new DbContextOptionsBuilder<RestaurantReservationDbContext>()
    .UseSqlServer(connectionString)
    .Options;

using var context = new RestaurantReservationDbContext(options);