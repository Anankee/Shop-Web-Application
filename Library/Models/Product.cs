using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(0.01, int.MaxValue)]
        [RegularExpression(@"^\d*,?[0-9]{0,2}$", ErrorMessage = "Please enter correct price number")]
        public double Price { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Amount { get; set; }
        public string ImageUrl { get; set; }
    }
}
