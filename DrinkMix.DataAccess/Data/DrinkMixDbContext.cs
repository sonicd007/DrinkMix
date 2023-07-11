using System;
using System.Collections.Generic;
using DrinkMix.Data.SeedData;
using DrinkMix.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrinkMix.Data;

public partial class DrinkMixDbContext : DbContext
{
    public DrinkMixDbContext()
    {
    }

    public DrinkMixDbContext(DbContextOptions<DrinkMixDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GlassType> GlassTypes { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<IngredientType> IngredientTypes { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("name=DrinkMixDatabase:ConnectionString", ServerVersion.Parse("10.5.18-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<GlassType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("GlassType");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Ingredient");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)");

            entity.HasIndex(e => e.IngredientTypeId, "ingredient_FK");

            entity.Property(e => e.IngredientTypeId).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.IngredientType).WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.IngredientTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ingredient_FK");
        });

        modelBuilder.Entity<IngredientType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("IngredientType");

            entity.HasIndex(e => e.Name, "IngredientType_UN").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Recipe");

            entity.HasIndex(e => e.GlassTypeId, "Recipe_FK");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.GlassTypeId).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.GlassType).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.GlassTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Recipe_FK");
        });

        modelBuilder.Entity<RecipeIngredient>(entity =>
        {
            entity.HasKey(e => new { e.RecipeId, e.IngredientId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.HasIndex(e => e.IngredientId, "RecipeIngredients_FK_1");

            entity.Property(e => e.RecipeId).HasColumnType("int(11)");
            entity.Property(e => e.IngredientId).HasColumnType("int(11)");
            entity.Property(e => e.Quantity).HasComment("The amount of said ingredient to use in recipe");
            entity.Property(e => e.UnitOfMeasurement).HasMaxLength(100);

            entity.HasOne(d => d.Ingredient).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RecipeIngredients_FK_1");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RecipeIngredients_FK");
        });

        modelBuilder.ApplyConfiguration(new IngredientTypeConfiguration());
        modelBuilder.ApplyConfiguration(new GlassTypeConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
