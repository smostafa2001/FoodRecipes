namespace FoodRecipes.DAL.Entities;
public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int RecipeId { get; set; }
}
