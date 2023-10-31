using Microsoft.EntityFrameworkCore;
using RestaurantRater.Data;
using RestaurantRater.Data.Entities;
using RestaurantRater.Models.Restaurant;

namespace RestaurantRater.Services.Restaurant;

public class RestaurantService : IRestaurantService
{
    private readonly RestaurantDbContext _context;

    public RestaurantService(RestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateRestaurantAsync(RestaurantCreate model)
    {
        var restaurant = new RestaurantEntity()
        {
            Name = model.Name,
            Location = model.Location
        };

        _context.Restaurants.Add(restaurant);
        var wasAdded = await _context.SaveChangesAsync() == 1;
        return wasAdded;
    }

    public Task<bool> DeleteRestaurantAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<RestaurantListItem>> GetAllRestaurantsAsync()
    {
        List<RestaurantListItem> restaurants = await _context.Restaurants
            .Include(r => r.Ratings)
            .Select(r => new RestaurantListItem()
            {
                Id = r.Id,
                Name = r.Name,
                Score = r.Score,
            }).ToListAsync();

            return restaurants;
    }

    public async Task<RestaurantDetail?> GetRestaurantByIdAsync(int id)
    {
        var restaurant = await _context.Restaurants
            .Include(r => r.Ratings)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (restaurant is null)
        {
            return null;
        }

        RestaurantDetail restaurantDetail = new()
                {
                    Id = restaurant.Id,
                    Name = restaurant.Name,
                    Location = restaurant.Location,
                    Score = restaurant.Score
                };

        return restaurantDetail;
    }
}