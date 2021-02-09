using System.Threading.Tasks;
using MealBlazorApp.Data;

namespace MealBlazorApp.Services
{
    public sealed class RecipeTypeRepository : Repository<RecipeType, string>
    {
        public RecipeTypeRepository(MealBlazorAppContext context) : base(context, context.RecipeTypes)
        {}

        public async override Task<RecipeType> Update(int id, RecipeType newType)
        {
            var type = await _dbSet.FindAsync(id);
            if (type == null)
                return null;

            if (type.Name != newType.Name)
                type.Name = newType.Name;

            _dbSet.Update(type);
            await _context.SaveChangesAsync();
        
            return type;
        }

        protected override string OrderKeySelector(RecipeType t) => t.Name;
    }
}