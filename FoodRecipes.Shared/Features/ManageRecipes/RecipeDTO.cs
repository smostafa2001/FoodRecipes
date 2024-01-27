namespace FoodRecipes.Shared.Features.ManageRecipes;
public class RecipeDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Originality { get; set; } = string.Empty;
    public int TimeInMinutes { get; set; }
    public int Price { get; set; }
    public List<IngredientDTO> Ingredients { get; set; } = new();
}