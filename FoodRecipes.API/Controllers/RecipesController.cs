using FoodRecipes.DAL;
using FoodRecipes.DAL.Entities;
using FoodRecipes.Shared.Features.ManageRecipes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodRecipes.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
    private readonly FoodRecipeDbContext _dbContext;
    private readonly ILogger<RecipesController> _logger;

    public RecipesController(FoodRecipeDbContext dbContext, ILogger<RecipesController> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var ingredients = await _dbContext.Recipes.Include(r => r.Ingredients).ToListAsync();
        return Ok(ingredients);
    }

    [HttpPost]
    public async Task<IActionResult> Add(RecipeDTO model)
    {
        try
        {
            Recipe recipe = new()
            {
                Name = model.Name,
                Description = model.Description,
                Originality = model.Originality,
                Price = model.Price,
                TimeInMinutes = model.TimeInMinutes,
                ImageUrl = "Not set",
                Ingredients = model.Ingredients.Select(i => new Ingredient { Name = i.Name }).ToList()
            };
            await _dbContext.Recipes.AddAsync(recipe);
            await _dbContext.SaveChangesAsync();
            return Ok(recipe.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Something went wrong");
            return BadRequest(-1);
        }
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> AddImage(int id)
    {
        var file = Request.Form.Files[0];
        if (file.Length == 0) return BadRequest();

        Recipe? recipe = _dbContext.Recipes.FirstOrDefault(r => r.Id == id);
        if (recipe is null) return BadRequest();

        var fileName = $"{Guid.NewGuid()}.jpg";
        var saveLocation = Path.Combine(Directory.GetCurrentDirectory(), "Images", fileName);
        var resizeOption = new ResizeOptions
        {
            Mode = ResizeMode.Pad,
            Size = new Size(800, 800)
        };

        using var image = Image.Load(file.OpenReadStream());
        image.Mutate(i => i.Resize(resizeOption));
        await image.SaveAsJpegAsync(saveLocation);
        recipe.ImageUrl = fileName;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}
