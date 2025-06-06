﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Services;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = config.GetConnectionString("DefaultConnection");
var options = new DbContextOptionsBuilder<RestaurantReservationDbContext>()
    .UseSqlServer(connectionString)
    .Options;
    
using var context = new RestaurantReservationDbContext(options);

var methods = new Methods(context);





