using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Models
{
    public class Steps
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        public virtual Recipe Recipe { get; set; }
        public Steps()
        {

        }
    }
}
