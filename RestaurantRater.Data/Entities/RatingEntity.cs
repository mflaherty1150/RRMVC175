namespace RestaurantRater.Data.Entities;

public class RatingEntity
{
    public int Id { get; set; }
    public int RestaurantId { get; set; }
    public double FoodScore { get; set; }
    public double CleanlinessScore { get; set; }
    public double AtmosphereScore { get; set; }

    public virtual RestaurantEntity Restaurant { get; set; } = null!;
}