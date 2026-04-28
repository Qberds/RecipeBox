using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using RecipeBox.Services;
using RecipeBox.ViewModels;
using System.Security.Claims;

namespace RecipeBox.Controllers;

[Authorize]
public class RecipesController : Controller
{
    private readonly RecipeService _recipeService;

    public RecipesController(RecipeService recipeService)
    {
        _recipeService = recipeService;
    }
    
    public async Task<IActionResult> MyRecipes()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.Identity?.Name;
        var userName = User.Identity?.Name ?? "Користувач";
        
        ViewBag.UserName = userName;
        var recipes = await _recipeService.GetUserRecipesAsync(userId);
        return View(recipes);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(RecipeViewModel model)
    {
        if (ModelState.IsValid)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.Identity?.Name;
            var userName = User.Identity?.Name ?? "Користувач";
            
            var recipe = new Recipe
            {
                Title = model.Title,
                Ingredients = model.Ingredients,
                Instruction = model.Instruction,
                Category = model.Category,
                CookingTime = model.CookingTime,
                AuthorId = userId,
                AuthorName = userName,
                Status = "На перевірці",
                CreatedAt = DateTime.Now
            };

            await _recipeService.CreateRecipeAsync(recipe);
            TempData["Success"] = "Рецепт успішно додано та відправлено на модерацію!";
            return RedirectToAction(nameof(MyRecipes));
        }
        
        return View(model);
    }
}