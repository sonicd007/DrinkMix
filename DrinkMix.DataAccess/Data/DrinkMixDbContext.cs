using System;
using System.Collections.Generic;
using System.Configuration;
using DrinkMix.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DrinkMix.DataAccess.Data;

public partial class DrinkMixDbContext : DbContext
{

    public DrinkMixDbContext(DbContextOptions<DrinkMixDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<DeviceCode> DeviceCodes { get; set; }

    public virtual DbSet<GlassType> GlassTypes { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<IngredientType> IngredientTypes { get; set; }

    public virtual DbSet<Key> Keys { get; set; }

    public virtual DbSet<PersistedGrant> PersistedGrants { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("(\"NormalizedName\" IS NOT NULL)");

            entity.Property(e => e.Id).HasMaxLength(255);
            entity.Property(e => e.ConcurrencyStamp).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClaimType).HasMaxLength(255);
            entity.Property(e => e.ClaimValue).HasMaxLength(255);
            entity.Property(e => e.RoleId).HasMaxLength(255);

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("(\"NormalizedUserName\" IS NOT NULL)");

            entity.Property(e => e.Id).HasMaxLength(255);
            entity.Property(e => e.ConcurrencyStamp).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.EmailConfirmed).HasColumnType("bit(1)");
            entity.Property(e => e.LockoutEnabled).HasColumnType("bit(1)");
            entity.Property(e => e.LockoutEnd).HasColumnType("timestamp without time zone");
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(255);
            entity.Property(e => e.PhoneNumberConfirmed).HasColumnType("bit(1)");
            entity.Property(e => e.SecurityStamp).HasMaxLength(255);
            entity.Property(e => e.TwoFactorEnabled).HasColumnType("bit(1)");
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        j.IndexerProperty<string>("UserId").HasMaxLength(255);
                        j.IndexerProperty<string>("RoleId").HasMaxLength(255);
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClaimType).HasMaxLength(255);
            entity.Property(e => e.ClaimValue).HasMaxLength(255);
            entity.Property(e => e.UserId).HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);
            entity.Property(e => e.ProviderDisplayName).HasMaxLength(255);
            entity.Property(e => e.UserId).HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.UserId).HasMaxLength(255);
            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);
            entity.Property(e => e.Value).HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<DeviceCode>(entity =>
        {
            entity.HasKey(e => e.UserCode);

            entity.HasIndex(e => e.DeviceCode1, "IX_DeviceCodes_DeviceCode").IsUnique();

            entity.HasIndex(e => e.Expiration, "IX_DeviceCodes_Expiration");

            entity.Property(e => e.UserCode).HasMaxLength(200);
            entity.Property(e => e.ClientId).HasMaxLength(200);
            entity.Property(e => e.CreationTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.DeviceCode1)
                .HasMaxLength(200)
                .HasColumnName("DeviceCode");
            entity.Property(e => e.Expiration).HasColumnType("timestamp without time zone");
            entity.Property(e => e.SessionId).HasMaxLength(100);
            entity.Property(e => e.SubjectId).HasMaxLength(200);
        });

        modelBuilder.Entity<GlassType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("GlassType_pkey");

            entity.ToTable("GlassType");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Ingredient_pkey");

            entity.ToTable("Ingredient");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.IngredientType).WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.IngredientTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ingredienttype_fk");

            entity.HasMany(i => i.RecipeIngredients)
                .WithOne(ri => ri.Ingredient)
                .HasForeignKey(ri => ri.IngredientId);

        });

        modelBuilder.Entity<IngredientType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("IngredientType_pkey");

            entity.ToTable("IngredientType");

            entity.Property(e => e.Name).HasMaxLength(100);

        });

        modelBuilder.Entity<Key>(entity =>
        {
            entity.HasIndex(e => e.Use, "IX_Keys_Use");

            entity.Property(e => e.Id).HasMaxLength(255);
            entity.Property(e => e.Algorithm).HasMaxLength(100);
            entity.Property(e => e.Created).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DataProtected).HasColumnType("bit(1)");
            entity.Property(e => e.IsX509certificate)
                .HasColumnType("bit(1)")
                .HasColumnName("IsX509Certificate");
            entity.Property(e => e.Use).HasMaxLength(255);
        });

        modelBuilder.Entity<PersistedGrant>(entity =>
        {
            entity.HasKey(e => e.Key);

            entity.HasIndex(e => e.ConsumedTime, "IX_PersistedGrants_ConsumedTime");

            entity.HasIndex(e => e.Expiration, "IX_PersistedGrants_Expiration");

            entity.HasIndex(e => new { e.SubjectId, e.ClientId, e.Type }, "IX_PersistedGrants_SubjectId_ClientId_Type");

            entity.HasIndex(e => new { e.SubjectId, e.SessionId, e.Type }, "IX_PersistedGrants_SubjectId_SessionId_Type");

            entity.Property(e => e.Key).HasMaxLength(200);
            entity.Property(e => e.ClientId).HasMaxLength(200);
            entity.Property(e => e.ConsumedTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CreationTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Expiration).HasColumnType("timestamp without time zone");
            entity.Property(e => e.SessionId).HasMaxLength(100);
            entity.Property(e => e.SubjectId).HasMaxLength(200);
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Recipe_pkey");

            entity.ToTable("Recipe");

            entity.Property(e => e.Description).HasColumnType("character varying");
            entity.Property(e => e.GlassTypeId).ValueGeneratedOnAdd();
            entity.Property(e => e.ImageUrl).HasColumnType("character varying");

            entity.HasOne(d => d.GlassType).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.GlassTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("glasstype_fk");

            entity.HasMany(i => i.RecipeIngredients)
                .WithOne(ri => ri.Recipe)
                .HasForeignKey(ri => ri.RecipeId);
        });

        modelBuilder.Entity<RecipeIngredient>(entity =>
        {
            entity.HasKey(ri => new { ri.IngredientId, ri.RecipeId }).HasName("RecipeIngredient_pk");

            entity.Property(e => e.IngredientId).ValueGeneratedOnAdd();
            entity.Property(e => e.RecipeId).ValueGeneratedOnAdd();
            entity.Property(e => e.UnitOfMeasurement).HasColumnType("character varying");

            entity.HasOne(d => d.Ingredient).WithMany(i => i.RecipeIngredients)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ingredient_fk");

            entity.HasOne(d => d.Recipe).WithMany(r => r.RecipeIngredients)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("recipe_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
