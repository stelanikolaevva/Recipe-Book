using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public string Number { get; set; }
        [Required]
        public string Description { get; set; }
        public string Image { get; set; }
        [Required]
        [DisplayName("For Recipe")]
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
        public Steps()
        {

        }
    }
}
