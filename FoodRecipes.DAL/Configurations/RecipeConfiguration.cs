using FoodRecipes.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodRecipes.DAL.Configurations;
public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.Property(r => r.ImageUrl).IsRequired().HasMaxLength(200);
        builder.Property(r => r.Name).IsRequired().HasMaxLength(200);
        builder.Property(r => r.Description).IsRequired();
        builder.Property(r => r.Originality).IsRequired().HasMaxLength(200);
    }
}