using System.ComponentModel.DataAnnotations;

namespace RecipeBox.ViewModels;

public class RecipeViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Назва рецепту обов'язкова")]
    [StringLength(100, ErrorMessage = "Назва не може бути довшою за 100 символів")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Інгредієнти обов'язкові")]
    public string Ingredients { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Інструкція обов'язкова")]
    public string Instruction { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Категорія обов'язкова")]
    public string Category { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Час приготування обов'язковий")]
    public string CookingTime { get; set; } = string.Empty;
    
    public string Status { get; set; } = "На перевірці";
}

public class RecipeUpdateStatusViewModel
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
}