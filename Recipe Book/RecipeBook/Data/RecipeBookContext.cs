using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeBook.Models;

namespace RecipeBook.Data
{
    public class RecipeBookContext : DbContext
    {
        public RecipeBookContext (DbContextOptions<RecipeBookContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .HasMany(c => c.Steps)
                .WithOne(e => e.Recipe);

            modelBuilder.Entity<Recipe>().ToTable("tblRecipe");
            modelBuilder.Entity<Ingredients>().ToTable("tblIngredient");
            modelBuilder.Entity<RecipeIngredients>().ToTable("tblRecipeIngredients");
        }
        public DbSet<RecipeBook.Models.Ingredients> Ingredients { get; set; }

        public DbSet<RecipeBook.Models.Recipe> Recipe { get; set; }

        public DbSet<RecipeBook.Models.Steps> Steps { get; set; }

        public DbSet<RecipeBook.Models.RecipeIngredients> RecipeIngredients { get; set; }

    }
}
