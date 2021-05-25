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

            modelBuilder.Entity<Recipe>()
               .HasMany(c => c.Ingredients)
               .WithOne(e => e.Recipe);
        }
        public DbSet<RecipeBook.Models.Ingredients> Ingredients { get; set; }

        public DbSet<RecipeBook.Models.Recipe> Recipe { get; set; }

        public DbSet<RecipeBook.Models.Steps> Steps { get; set; }

    }
}
