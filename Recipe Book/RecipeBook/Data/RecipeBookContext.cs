using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeBook.Models;
using RecipeBook.Dtos;

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
            modelBuilder.Entity<RecipeManager>()
                .HasOne(a => a.Recipes)
                .WithOne(b => b.RecipeManager)
                .HasForeignKey<Recipe>(b => b.RecipeManagerRef);


            modelBuilder.Entity<Recipe>()
                .HasMany(c => c.Steps)
                .WithOne(e => e.Recipe);

            modelBuilder.Entity<Recipe>()
               .HasMany(c => c.Ingredients)
               .WithOne(e => e.Recipe);
        }
        public DbSet<RecipeBook.Models.Ingredients> Ingredients { get; set; }

        public DbSet<RecipeBook.Models.Recipe> Recipe { get; set; }

        public DbSet<RecipeBook.Models.RecipeManager> RecipeBook { get; set; }

        public DbSet<RecipeBook.Models.Steps> Steps { get; set; }

    }
}
