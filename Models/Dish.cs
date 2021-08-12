using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dish
    {
        public int DishID { get; set; }

        [Required]
        [MinLength(2, ErrorMessage ="Dish Name must be at least 2 characters")]
        public string Name { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Chef's Name must be at least 2 characters")]
        public string Chef { get; set; }

        [Required]
        [Range(1,5, ErrorMessage = "Must be a number between 1 and 5")]
        public int Tastiness {get; set; }

        [Required]
        [Range(0, 3000, ErrorMessage = "Calories are required")]
        public int Calories { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Description must be at least 4 characters.")]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}