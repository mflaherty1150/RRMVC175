using System.ComponentModel.DataAnnotations;

namespace RestaurantRater.Data.Entities;

public class RestaurantEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string name { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Location { get; set; } = string.Empty;

    public virtual List<RatingEntity> Ratings { get; set; } = new List<RatingEntity>();

    public double AverageFoodScore
    {
        get
        {
            return Ratings.Count > 0 ? Ratings.Select(r => r.FoodScore).Sum() / Ratings.Count : 0;
        }
    }

    public double AverageCleanlinessScore
    {
        get
        {
            return Ratings.Count > 0 ? Ratings.Select(r => r.CleanlinessScore).Sum() / Ratings.Count : 0;
        }
    }

    public double AverageAtmosphereScore
    {
        get
        {
            return Ratings.Count > 0 ? Ratings.Select(r => r.AtmosphereScore).Sum() / Ratings.Count : 0;
        }
    }

    public double Score 
    {
        get
        {
            return (AverageFoodScore + AverageCleanlinessScore + AverageAtmosphereScore) / 3;
        }
    }
}