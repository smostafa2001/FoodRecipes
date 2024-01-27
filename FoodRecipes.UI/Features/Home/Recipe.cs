namespace FoodRecipes.UI.Features.Home;

public class Recipe
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Originality { get; set; } = string.Empty;
    public int TimeInMinutes { get; set; }
    public string TimeInString => $"{TimeInMinutes / 60}h {TimeInMinutes % 60}m";
    public int Price { get; set; }
    public IEnumerable<Ingredient> Ingredients { get; set; } = Array.Empty<Ingredient>();
}