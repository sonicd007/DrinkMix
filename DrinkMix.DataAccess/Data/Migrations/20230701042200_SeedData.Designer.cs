﻿// <auto-generated />
using DrinkMix.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DrinkMix.Migrations.DrinkMixDb
{
    [DbContext(typeof(DrinkMixDbContext))]
    [Migration("20230701042200_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8_general_ci")
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8");

            modelBuilder.Entity("DrinkMix.Models.GlassType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("GlassType", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Red Wine Glass"
                        },
                        new
                        {
                            Id = 2,
                            Name = "White Wine Glass"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Flute Glass"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Cocktail Glass"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Highball Glass"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Lowball Glass"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Irish Coffee Glass"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Hurricane Glass"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Martini Glass"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Margarita Glass"
                        },
                        new
                        {
                            Id = 11,
                            Name = "The glencairn Whiskey Glass"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Snifter Glass"
                        });
                });

            modelBuilder.Entity("DrinkMix.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("IngredientTypeId")
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("Ingredient", (string)null);
                });

            modelBuilder.Entity("DrinkMix.Models.IngredientType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Name" }, "IngredientType_UN")
                        .IsUnique();

                    b.ToTable("IngredientType", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Whiskey"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Vodka"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Gin"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Rum"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Tequila"
                        });
                });

            modelBuilder.Entity("DrinkMix.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("GlassTypeId")
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "GlassTypeId" }, "Recipe_FK");

                    b.ToTable("Recipe", (string)null);
                });

            modelBuilder.Entity("DrinkMix.Models.RecipeIngredient", b =>
                {
                    b.Property<int>("RecipeId")
                        .HasColumnType("int(11)");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int(11)");

                    b.Property<double>("Quantity")
                        .HasColumnType("double")
                        .HasComment("The amount of said ingredient to use in recipe");

                    b.Property<string>("UnitOfMeasurement")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("RecipeId", "IngredientId")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex(new[] { "IngredientId" }, "RecipeIngredients_FK_1");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("DrinkMix.Models.Ingredient", b =>
                {
                    b.HasOne("DrinkMix.Models.IngredientType", "IdNavigation")
                        .WithOne("Ingredient")
                        .HasForeignKey("DrinkMix.Models.Ingredient", "Id")
                        .IsRequired()
                        .HasConstraintName("Ingredient_FK");

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("DrinkMix.Models.Recipe", b =>
                {
                    b.HasOne("DrinkMix.Models.GlassType", "GlassType")
                        .WithMany("Recipes")
                        .HasForeignKey("GlassTypeId")
                        .IsRequired()
                        .HasConstraintName("Recipe_FK");

                    b.Navigation("GlassType");
                });

            modelBuilder.Entity("DrinkMix.Models.RecipeIngredient", b =>
                {
                    b.HasOne("DrinkMix.Models.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientId")
                        .IsRequired()
                        .HasConstraintName("RecipeIngredients_FK_1");

                    b.HasOne("DrinkMix.Models.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .IsRequired()
                        .HasConstraintName("RecipeIngredients_FK");

                    b.Navigation("Ingredient");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("DrinkMix.Models.GlassType", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("DrinkMix.Models.Ingredient", b =>
                {
                    b.Navigation("RecipeIngredients");
                });

            modelBuilder.Entity("DrinkMix.Models.IngredientType", b =>
                {
                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("DrinkMix.Models.Recipe", b =>
                {
                    b.Navigation("RecipeIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
