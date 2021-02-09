using System.Linq;
using MealBlazorApp.Data;
using MealBlazorApp.Views;

namespace MealBlazorApp.Services
{
    public sealed class RecipeConverter : IConverter<Recipe, RecipeView>
    {
        MealBlazorAppContext _context;

        public RecipeConverter(MealBlazorAppContext context)
        {
            _context = context;
        }

        public Recipe Convert(RecipeView model)
        {
            var type = _context.RecipeTypes.Where(t => t.Name == model.TypeName).Single();
            return new Recipe
            {
                Name = model.Name,
                Description = model.Description,
                Type = type
            };
        }

        public RecipeView Convert(Recipe view)
        {
            return new RecipeView
            {
                Name = view.Name,
                Description = view.Description,
                TypeName = view.Type.Name
            };
        }
    }
}