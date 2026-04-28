using Microsoft.AspNetCore.Mvc;
using RecipeBox.Services;

namespace RecipeBox.Controllers;

public class HomeController : Controller
{
    private readonly RecipeService _recipeService;

    public HomeController(RecipeService recipeService)
    {
        _recipeService = recipeService;
    }
    public async Task<IActionResult> Index()
    {
        var recipes = await _recipeService.GetPublishedRecipesAsync();
        return View(recipes);
    }
    public async Task<IActionResult> Details(int id)
    {
        var recipe = await _recipeService.GetRecipeByIdAsync(id);
        if (recipe == null)
        {
            return NotFound();
        }
        return View(recipe);
    }
}