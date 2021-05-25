using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Models
{
    public class Recipe
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DisplayName("Cooking time")]
        public string CookingTime { get; set; }
        [Required]
        public int Servings { get; set; }
        public byte[] Image { get; set; }
        [Required]
        public DateTime Published { get; set; }
        [Required]
        [DisplayName("Created by")]
        public string CreatedBy { get; set; }
        public virtual ICollection<Steps> Steps { get; set; }
       
        public virtual ICollection<Ingredients> Ingredients { get; set; }
        public Recipe()
        {

        }
    }
}
