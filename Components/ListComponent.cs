using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MealBlazorApp.Services;

namespace MealBlazorApp.Components
{
    public abstract class ListComponent<TModel> : ComponentBase
    {
        protected List<TModel> Models { get; set; }

        [Inject]
        protected IRepository<TModel> Repository { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Models = await Repository.GetList();
        }

        protected async Task Refresh()
        {
            Models = await Repository.GetList();
        }

        protected abstract string AddModalTitle();
        protected abstract string EditModalTitle();
        protected abstract string DeleteModalTitle();
    }
}