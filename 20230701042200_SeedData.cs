using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DrinkMix.Migrations.DrinkMixDb
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GlassType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Red Wine Glass" },
                    { 2, "White Wine Glass" },
                    { 3, "Flute Glass" },
                    { 4, "Cocktail Glass" },
                    { 5, "Highball Glass" },
                    { 6, "Lowball Glass" },
                    { 7, "Irish Coffee Glass" },
                    { 8, "Hurricane Glass" },
                    { 9, "Martini Glass" },
                    { 10, "Margarita Glass" },
                    { 11, "The glencairn Whiskey Glass" },
                    { 12, "Snifter Glass" }
                });

            migrationBuilder.InsertData(
                table: "IngredientType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Whiskey" },
                    { 2, "Vodka" },
                    { 3, "Gin" },
                    { 4, "Rum" },
                    { 5, "Tequila" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GlassType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GlassType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GlassType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GlassType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GlassType",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GlassType",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "GlassType",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "GlassType",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "GlassType",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "GlassType",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "GlassType",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "GlassType",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "IngredientType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IngredientType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IngredientType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IngredientType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "IngredientType",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
