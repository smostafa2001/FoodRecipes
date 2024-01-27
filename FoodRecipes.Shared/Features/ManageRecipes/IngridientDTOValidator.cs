using FluentValidation;

namespace FoodRecipes.Shared.Features.ManageRecipes;

public class IngredientDTOValidator : AbstractValidator<IngredientDTO>
{
    public IngredientDTOValidator()
    {
        RuleFor(r => r.Name).NotEmpty().WithMessage("Please enter a name!");
    }
}