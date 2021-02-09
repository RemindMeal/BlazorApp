using System.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MealBlazorApp.Data
{
    public sealed class RecipeType
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le groupe doit avoir un nom")]
        public string Name { get; set; }

        public ICollection<Recipe> Recipes { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}