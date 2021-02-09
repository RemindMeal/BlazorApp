using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using MealBlazorApp.Data;

namespace MealBlazorApp.Services
{
    public abstract class Repository<TModel, TOrderKey> : IRepository<TModel> where TModel: class
    {
        protected readonly MealBlazorAppContext _context;
        protected readonly DbSet<TModel> _dbSet;

        protected Repository(MealBlazorAppContext context, DbSet<TModel> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }

        public virtual async Task<List<TModel>> GetList()
        {
            return _dbSet.OrderBy(OrderKeySelector).ToList();
        }

        protected abstract TOrderKey OrderKeySelector(TModel t);

        public async Task<TModel> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TModel> Insert(TModel model)
        {
            _dbSet.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<TModel> Delete(int id)
        {
            var model = await _dbSet.FindAsync(id);

            if (model == null)
                return default(TModel);

            _dbSet.Remove(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public abstract Task<TModel> Update(int id, TModel m);
    }
}