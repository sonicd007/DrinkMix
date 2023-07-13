using Microsoft.EntityFrameworkCore.Migrations;
using System.Xml.Linq;

#nullable disable

namespace DrinkMix.DataAccess.DrinkMix.DataAccess.Data.Migrations
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
                    { 5, "Tequila" },
                    { 6, "Sweetener" },
                    { 7, "Tincture" },
                    { 8, "Juice"}
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GlassType",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });

            migrationBuilder.DeleteData(
                table: "IngredientType",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6 });
        }
    }
}
