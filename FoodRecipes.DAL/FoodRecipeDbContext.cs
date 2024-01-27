using FoodRecipes.DAL.Configurations;
using FoodRecipes.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodRecipes.DAL;

public class FoodRecipeDbContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public FoodRecipeDbContext(DbContextOptions options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(IngredientConfiguration).Assembly);
}
