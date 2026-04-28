namespace RecipeBox.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Ingredients { get; set; } = string.Empty;
    public string Instruction { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string CookingTime { get; set; } = string.Empty;
    public string AuthorId { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
    public string Status { get; set; } = "На перевірці"; // На перевірці / Опубліковано / Відхилено
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}