using Microsoft.AspNetCore.Mvc;
using RestaurantRater.Models.Restaurant;
using RestaurantRater.Services.Restaurant;

namespace RestaurantRater.Mvc.Controllers;

public class RestaurantController : Controller
{
    private IRestaurantService _service;
    public RestaurantController(IRestaurantService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        List<RestaurantListItem> restaurants = await _service.GetAllRestaurantsAsync();
        return View(restaurants);
    }
}