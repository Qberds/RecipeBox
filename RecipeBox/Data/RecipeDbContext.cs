using Microsoft.EntityFrameworkCore;
using RecipeBox.Models;
namespace RecipeBox.Data;

public class RecipeDbContext : DbContext
{
    public RecipeDbContext(DbContextOptions<RecipeDbContext> options) : base(options) { }
    
    public DbSet<Recipe> Recipes => Set<Recipe>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>().HasData(
            new Recipe
            {
                Id = 1,
                Title = "Класичний борщ",
                Ingredients =
                    "Буряк, капуста, картопля, морква, цибуля, томатна паста, м'ясо, сіль, перець, лавровий лист",
                Instruction =
                    "1. Зварити бульйон. 2. Підсмажити овочі. 3. Додати капусту та картоплю. 4. Варити до готовності. 5. Додати спеції.",
                Category = "Супи",
                CookingTime = "1.5 години",
                AuthorId = "admin",
                AuthorName = "Admin",
                Status = "Опубліковано",
                CreatedAt = new DateTime(2026, 03, 20, 10, 0, 0)
            },
            new Recipe
            {
                Id = 2,
                Title = "Вареники з картоплею",
                Ingredients = "Борошно, вода, сіль, картопля, цибуля, олія, перець",
                Instruction =
                    "1. Замісити тісто. 2. Приготувати начинку. 3. Зліпити вареники. 4. Відварити в підсоленій воді. 5. Подавати зі сметаною.",
                Category = "Основні страви",
                CookingTime = "1 година",
                AuthorId = "admin",
                AuthorName = "Admin",
                Status = "Опубліковано",
                CreatedAt = new DateTime(2026, 03, 21, 12, 0, 0)
            },
            new Recipe
            {
                Id = 3,
                Title = "Цезар з куркою",
                Ingredients =
                    "Куряче філе, салат ромен, пармезан, сухарики, яйце, оливкова олія, гірчиця, лимонний сік",
                Instruction =
                    "1. Запекти курку. 2. Приготувати соус. 3. Нарізати салат. 4. Змішати всі інгредієнти. 5. Посипати пармезаном.",
                Category = "Салати",
                CookingTime = "40 хвилин",
                AuthorId = "user1",
                AuthorName = "Олена Петренко",
                Status = "На перевірці",
                CreatedAt = new DateTime(2026, 03, 22, 14, 0, 0)
            },
            new Recipe
            {
                Id = 4,
                Title = "Медовик",
                Ingredients = "Борошно, мед, яйця, цукор, сода, сметана, вершкове масло",
                Instruction =
                    "1. Замісити тісто. 2. Випекти коржі. 3. Приготувати крем. 4. Зібрати торт. 5. Залишити просочитися на ніч.",
                Category = "Десерти",
                CookingTime = "2 години + ніч",
                AuthorId = "admin",
                AuthorName = "Admin",
                Status = "Опубліковано",
                CreatedAt = new DateTime(2026, 03, 23, 16, 0, 0)
            },
            new Recipe
            {
                Id = 5,
                Title = "Грецький салат",
                Ingredients =
                    "Помідори, огірки, болгарський перець, червона цибуля, фета, маслини, оливкова олія, орегано",
                Instruction =
                    "1. Нарізати всі овочі. 2. Додати фету та маслини. 3. Заправити оливковою олією. 4. Посипати орегано.",
                Category = "Салати",
                CookingTime = "15 хвилин",
                AuthorId = "user2",
                AuthorName = "Марія Іваненко",
                Status = "Відхилено",
                CreatedAt = new DateTime(2026, 03, 24, 18, 0, 0)
            }
        );

    }
}