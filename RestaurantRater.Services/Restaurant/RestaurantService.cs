using Microsoft.EntityFrameworkCore;
using RestaurantRater.Data;
using RestaurantRater.Models.Restaurant;

namespace RestaurantRater.Services.Restaurant;

public class RestaurantService : IRestaurantService
{
    private readonly RestaurantDbContext _context;

    public RestaurantService(RestaurantDbContext context)
    {
        _context = context;
    }

    public Task<bool> CreateRestaurantAsync(RestaurantCreate model)
    {
        throw new NotImplementedException();
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
                Name = r.name,
                Score = r.Score,
            }).ToListAsync();

            return restaurants;
    }
}