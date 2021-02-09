using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MealBlazorApp.Data
{
    public sealed class Meal
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        // Relationships
        public ICollection<Presence> Presences { get; } = new List<Presence>();
        public ICollection<Cooking> Cookings { get; } = new List<Cooking>();

        public override string ToString()
        {
            return $"Meal of {Date}";
        }
    }
}