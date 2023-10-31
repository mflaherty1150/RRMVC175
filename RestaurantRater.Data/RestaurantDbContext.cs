using Microsoft.EntityFrameworkCore;
using RestaurantRater.Data.Entities;

namespace RestaurantRater.Data;

public class RestaurantDbContext : DbContext
{
    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) {}

    public DbSet<RestaurantEntity> Restaurants { get; set; }
    public DbSet<RatingEntity> Ratings { get; set; }
}