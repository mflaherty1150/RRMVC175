using RestaurantRater.Models.Restaurant;

namespace RestaurantRater.Services.Restaurant;

public interface IRestaurantService
{
    Task<bool> CreateRestaurantAsync(RestaurantCreate model);
    Task<List<RestaurantListItem>> GetAllRestaurantsAsync();
    Task<RestaurantDetail?> GetRestaurantByIdAsync(int id);
    Task<bool> UpdateRestaurantAsync(RestaurantEdit model);
    Task<bool> DeleteRestaurantAsync(int id);
}