using System.ComponentModel.DataAnnotations;

namespace MealBlazorApp.Views
{
    public sealed class RecipeView
    {
        [Required(ErrorMessage = "Votre recette doit avoir un nom")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Votre recette doit avoir une catégorie")]
        public string TypeName { get; set; }

        public override string ToString()
        {
            return TypeName;
        }
    }
}