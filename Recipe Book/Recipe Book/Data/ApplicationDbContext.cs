using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Recipe_Book.Models;

namespace Recipe_Book.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Recipe_Book.Models.Ingredients> Ingredients { get; set; }
        public DbSet<Recipe_Book.Models.Recipe> Recipe { get; set; }
        public DbSet<Recipe_Book.Models.RecipeBook> RecipeBook { get; set; }
        public DbSet<Recipe_Book.Models.Steps> Steps { get; set; }
    }
}
