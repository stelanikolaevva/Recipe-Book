using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_Book.Models
{
    public class Recipe
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string CookingTime { get; set; }
        public int Servings { get; set; }
        public string Image { get; set; }

        public Recipe()
        {

        }
    }
}
