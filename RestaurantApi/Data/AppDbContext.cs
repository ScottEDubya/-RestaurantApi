using Microsoft.EntityFrameworkCore;
using RestaurantApi.Models;
using System;

namespace RestaurantApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options, bool isInMemory = true) : base(options)
        {
            if(!isInMemory)
            {
                Database.Migrate(); //will make db if not exist
            }
        }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        //dining room
        //menus
        //orders
        //employees
        //customers
    }
}
