namespace FoodRecipes.DAL.Entities;
public class Recipe
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Originality { get; set; } = string.Empty;
    public int TimeInMinutes { get; set; }
    public int Price { get; set; }
    public List<Ingredient> Ingredients { get; set; } = new();
}
