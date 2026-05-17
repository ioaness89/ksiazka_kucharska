using System;
using System.Collections.Generic;
using System.Text;

namespace ksiazka_kucharska.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Category { get; set; }
        public int PreparationTimeMinutes { get; set; }
        public string? Description { get; set; }
        public List<string>? Ingredients { get; set; }
        public bool IsFavorite { get; set; }
    }
}
