using System.ComponentModel.DataAnnotations;

namespace RestaurantRater.Models.Restaurant;

public class RestaurantCreate
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Location { get; set; } = string.Empty;
}