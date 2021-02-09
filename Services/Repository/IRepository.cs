using System.Collections.Generic;
using System.Threading.Tasks;

namespace MealBlazorApp.Services
{
    public interface IRepository<TModel>
    {
        Task<List<TModel>> GetList();
        Task<TModel> GetById(int id);
        Task<TModel> Insert(TModel model);
        Task<TModel> Update(int id, TModel m);
        Task<TModel> Delete(int id);
    }
}