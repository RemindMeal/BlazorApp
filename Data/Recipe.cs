using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MealBlazorApp.Data
{
    public sealed class Recipe
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public RecipeType Type { get; set; }

        public ICollection<Cooking> Cookings { get; set; } = new List<Cooking>();

        public override string ToString()
        {
            return Name;
        }
    }
}