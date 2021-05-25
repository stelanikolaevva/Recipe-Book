using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Models
{
    public class Ingredients
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public string Unit { get; set; }
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
        public Ingredients()
        {

        }
    }
}
