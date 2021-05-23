using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_Book.Models
{
    public class Steps
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Steps()
        {

        }
    }
}
