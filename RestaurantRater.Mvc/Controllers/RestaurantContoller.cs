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

    [ActionName("Details")]
    public async Task<IActionResult> Restaurant(int id)
    {
        var restaurantDetail = await _service.GetRestaurantByIdAsync(id);

        if (restaurantDetail is null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(restaurantDetail);
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(RestaurantCreate model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await _service.CreateRestaurantAsync(model);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var restaurantDetail = await _service.GetRestaurantByIdAsync(id);

        if (restaurantDetail is null)
        {
            return RedirectToAction(nameof(Index));
        }

        var restaurantEdit = new RestaurantEdit()
        {
            Id = restaurantDetail.Id,
            Name = restaurantDetail.Name,
            Location = restaurantDetail.Location
        };

        return View(restaurantEdit);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(RestaurantEdit model)
    {
        if (!ModelState.IsValid)
        {
            return View(ModelState);
        }

        var restaurantDetail = _service.GetRestaurantByIdAsync(model.Id);

        if (restaurantDetail is null)
        {
            return RedirectToAction(nameof(Index));
        }

        if (await _service.UpdateRestaurantAsync(model))
        {
            return RedirectToAction("Details", new { id = model.Id});
        }

        return View(ModelState);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var restaurantDetail = await _service.GetRestaurantByIdAsync(id);

        return View(restaurantDetail);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(RestaurantDetail model)
    {
        if (await _service.GetRestaurantByIdAsync(model.Id) is null)
        {
            return RedirectToAction(nameof(Index));
        }

        var wasDeleted = _service.DeleteRestaurantAsync(model.Id);

        return RedirectToAction(nameof(Index));
    }
}