using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealBlazorApp.Data;
using Microsoft.EntityFrameworkCore;

namespace MealBlazorApp.Services
{
    public sealed class RecipeRepository : Repository<Recipe, string>
    {
        public RecipeRepository(MealBlazorAppContext context) : base(context, context.Recipes)
        {}

        public async override Task<List<Recipe>> GetList()
        {
            return await _dbSet.Include(r => r.Type).OrderBy(r => r.Name).ToListAsync();
        }

        public async override Task<Recipe> Update(int id, Recipe newRecipe)
        {
            var recipe = await _dbSet.FindAsync(id);
            if (recipe == null)
                return null;
 
            recipe.Name = newRecipe.Name;
            recipe.Description = newRecipe.Description;
            recipe.Type = newRecipe.Type;

            _dbSet.Update(recipe);
            await _context.SaveChangesAsync();
        
            return recipe;
        }

        protected override string OrderKeySelector(Recipe t) => t.Name;
    }
}