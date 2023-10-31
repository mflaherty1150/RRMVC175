using System.ComponentModel.DataAnnotations;

namespace RestaurantRater.Models.Restaurant;

public class RestaurantDetail
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;

    [Display(Name = "Average Score")]
    public double Score { get; set; }
}