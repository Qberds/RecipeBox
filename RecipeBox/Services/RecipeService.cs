using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using RecipeBox.Data;
using RecipeBox.Models;

namespace RecipeBox.Services;

public class RecipeService
{
    private readonly RecipeDbContext _db;
    private readonly IDistributedCache _cache;
    private const string PublishedCacheKey = "recipes_published_all";

    public RecipeService(RecipeDbContext db, IDistributedCache cache)
    {
        _db = db;
        _cache = cache;
    }
    public async Task<List<Recipe>> GetPublishedRecipesAsync()
    {
        var cachedRecipes = await _cache.GetStringAsync(PublishedCacheKey);
        
        if (!string.IsNullOrEmpty(cachedRecipes))
        {
            return JsonSerializer.Deserialize<List<Recipe>>(cachedRecipes) ?? new List<Recipe>();
        }

        var recipes = await _db.Recipes
            .Where(r => r.Status == "Опубліковано")
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();

        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        };

        await _cache.SetStringAsync(PublishedCacheKey, JsonSerializer.Serialize(recipes), options);
        
        return recipes;
    }
    
    public async Task<Recipe?> GetRecipeByIdAsync(int id)
    {
        return await _db.Recipes.FindAsync(id);
    }
    
    public async Task<List<Recipe>> GetUserRecipesAsync(string authorId)
    {
        return await _db.Recipes
            .Where(r => r.AuthorId == authorId)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();
    }
    
    public async Task<List<Recipe>> GetAllRecipesForModerationAsync()
    {
        return await _db.Recipes
            .Where(r => r.Status == "На перевірці" || r.Status == "Відхилено")
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();
    }
    
    public async Task CreateRecipeAsync(Recipe recipe)
    {
        recipe.CreatedAt = DateTime.Now;
        recipe.Status = "На перевірці";
        
        await _db.Recipes.AddAsync(recipe);
        await _db.SaveChangesAsync();
        await _cache.RemoveAsync(PublishedCacheKey);
    }
    
    public async Task ChangeStatusAsync(int id, string status)
    {
        var recipe = await _db.Recipes.FindAsync(id);
        if (recipe != null)
        {
            recipe.Status = status;
            await _db.SaveChangesAsync();
            await _cache.RemoveAsync(PublishedCacheKey);
        }
    }
    public async Task UpdateRecipeAsync(Recipe recipe)
    {
        _db.Recipes.Update(recipe);
        await _db.SaveChangesAsync();
        await _cache.RemoveAsync(PublishedCacheKey);
    }
}