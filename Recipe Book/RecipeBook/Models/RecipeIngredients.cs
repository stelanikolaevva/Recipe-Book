using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Models
{
    public class RecipeIngredients
    {
        public int Id { get; set; }

        [Display(Name = "Recipe Name")]
        public int RecipesId { get; set; }

        [Display(Name = "Ingredient Name")]
        public int IngredientsId { get; set; }

        public int Quantity { get; set; }
        public string Unit { get; set; }

        public Recipe Recipes { get; set; }
        public Ingredients Ingredients { get; set; }
    }
}
