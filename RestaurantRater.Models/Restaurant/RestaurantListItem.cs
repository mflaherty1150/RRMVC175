using System.ComponentModel.DataAnnotations;

namespace RestaurantRater.Models.Restaurant;

public class RestaurantListItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Average Score")]
    public double Score { get; set; }
}