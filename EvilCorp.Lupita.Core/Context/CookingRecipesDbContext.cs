using System;
using System.Collections.Generic;
using EvilCorp.Lupita.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace EvilCorp.Lupita.Core.Context;

public partial class CookingRecipesDbContext : DbContext
{
    public CookingRecipesDbContext()
    {
    }

    public CookingRecipesDbContext(DbContextOptions<CookingRecipesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Measure> Measures { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeAuthor> RecipeAuthors { get; set; }

    public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    public virtual DbSet<RecipeRating> RecipeRatings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=A032381\\SQLEXPRESS;Database=CookingRecipes;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Author__3213E83FDB5E7B7C");

            entity.ToTable("Author");

            entity.HasIndex(e => e.Email, "UQ__Author__AB6E6164D4993BAC").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ingredie__3213E83F36B4A976");

            entity.ToTable("Ingredient");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Measure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Measure__3213E83F039EACD6");

            entity.ToTable("Measure");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rating__3213E83F13ED394E");

            entity.ToTable("Rating");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Recipe__3213E83FAEEA7867");

            entity.ToTable("Recipe");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CookTime).HasColumnName("cook_time");
            entity.Property(e => e.Course)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("course");
            entity.Property(e => e.Cuisine)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cuisine");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Instructions)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("instructions");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PrepTime).HasColumnName("prep_time");
        });

        modelBuilder.Entity<RecipeAuthor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RecipeAuthor");

            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

            entity.HasOne(d => d.Author).WithMany()
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_author_recipe");

            entity.HasOne(d => d.Recipe).WithMany()
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_recipe_author");
        });

        modelBuilder.Entity<RecipeIngredient>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RecipeIngredient");

            entity.Property(e => e.Amount)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
            entity.Property(e => e.MeasureId).HasColumnName("measure_id");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

            entity.HasOne(d => d.Ingredient).WithMany()
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ingredient");

            entity.HasOne(d => d.Measure).WithMany()
                .HasForeignKey(d => d.MeasureId)
                .HasConstraintName("fk_measure");

            entity.HasOne(d => d.Recipe).WithMany()
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_recipe");
        });

        modelBuilder.Entity<RecipeRating>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RecipeRating");

            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.RatingId).HasColumnName("rating_id");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

            entity.HasOne(d => d.Author).WithMany()
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_author_rating");

            entity.HasOne(d => d.Rating).WithMany()
                .HasForeignKey(d => d.RatingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rating_recipe");

            entity.HasOne(d => d.Recipe).WithMany()
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_recipe_rating");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
