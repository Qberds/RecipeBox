using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeBox.Services;
using RecipeBox.ViewModels;

namespace RecipeBox.Controllers;

[Authorize(Roles = "moderator")]
public class ModerationController : Controller
{
    private readonly RecipeService _recipeService;

    public ModerationController(RecipeService recipeService)
    {
        _recipeService = recipeService;
    }
    
    public async Task<IActionResult> Index()
    {
        var recipes = await _recipeService.GetAllRecipesForModerationAsync();
        return View(recipes);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ChangeStatus(RecipeUpdateStatusViewModel model)
    {
        if (ModelState.IsValid)
        {
            await _recipeService.ChangeStatusAsync(model.Id, model.Status);
            TempData["Success"] = $"Статус рецепту змінено на '{model.Status}'";
        }
        
        return RedirectToAction(nameof(Index));
    }
}