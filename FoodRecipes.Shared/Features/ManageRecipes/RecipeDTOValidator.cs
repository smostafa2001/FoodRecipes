using FluentValidation;

namespace FoodRecipes.Shared.Features.ManageRecipes;

public class RecipeDTOValidator : AbstractValidator<RecipeDTO>
{
    public RecipeDTOValidator()
    {
        RuleFor(r => r.Name).NotEmpty().WithMessage("Please enter a name!");
        RuleFor(r => r.Description).NotEmpty().WithMessage("Please enter a description!");
        RuleFor(r => r.Originality).NotEmpty().WithMessage("Please enter a originality!");
        RuleFor(r => r.Price).GreaterThan(0).WithMessage("Please enter a value greater than 0!");
        RuleFor(r => r.TimeInMinutes).GreaterThan(0).WithMessage("Please enter a value greater than 0!");
        RuleFor(r => r.Ingredients).NotEmpty().WithMessage("Please add a Ingredient!");
        RuleForEach(r => r.Ingredients).SetValidator(new IngredientDTOValidator());
    }
}