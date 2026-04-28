using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeBox.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Ingredients = table.Column<string>(type: "TEXT", nullable: false),
                    Instruction = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    CookingTime = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorId = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorName = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "AuthorId", "AuthorName", "Category", "CookingTime", "CreatedAt", "Ingredients", "Instruction", "Status", "Title" },
                values: new object[,]
                {
                    { 1, "admin", "Admin", "Супи", "1.5 години", new DateTime(2026, 3, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "Буряк, капуста, картопля, морква, цибуля, томатна паста, м'ясо, сіль, перець, лавровий лист", "1. Зварити бульйон. 2. Підсмажити овочі. 3. Додати капусту та картоплю. 4. Варити до готовності. 5. Додати спеції.", "Опубліковано", "Класичний борщ" },
                    { 2, "admin", "Admin", "Основні страви", "1 година", new DateTime(2026, 3, 21, 12, 0, 0, 0, DateTimeKind.Unspecified), "Борошно, вода, сіль, картопля, цибуля, олія, перець", "1. Замісити тісто. 2. Приготувати начинку. 3. Зліпити вареники. 4. Відварити в підсоленій воді. 5. Подавати зі сметаною.", "Опубліковано", "Вареники з картоплею" },
                    { 3, "user1", "Олена Петренко", "Салати", "40 хвилин", new DateTime(2026, 3, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), "Куряче філе, салат ромен, пармезан, сухарики, яйце, оливкова олія, гірчиця, лимонний сік", "1. Запекти курку. 2. Приготувати соус. 3. Нарізати салат. 4. Змішати всі інгредієнти. 5. Посипати пармезаном.", "На перевірці", "Цезар з куркою" },
                    { 4, "admin", "Admin", "Десерти", "2 години + ніч", new DateTime(2026, 3, 23, 16, 0, 0, 0, DateTimeKind.Unspecified), "Борошно, мед, яйця, цукор, сода, сметана, вершкове масло", "1. Замісити тісто. 2. Випекти коржі. 3. Приготувати крем. 4. Зібрати торт. 5. Залишити просочитися на ніч.", "Опубліковано", "Медовик" },
                    { 5, "user2", "Марія Іваненко", "Салати", "15 хвилин", new DateTime(2026, 3, 24, 18, 0, 0, 0, DateTimeKind.Unspecified), "Помідори, огірки, болгарський перець, червона цибуля, фета, маслини, оливкова олія, орегано", "1. Нарізати всі овочі. 2. Додати фету та маслини. 3. Заправити оливковою олією. 4. Посипати орегано.", "Відхилено", "Грецький салат" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
