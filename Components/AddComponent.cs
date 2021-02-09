using System.Threading.Tasks;
using Blazored.Modal;
using Blazored.Modal.Services;
using MealBlazorApp.Services;
using Microsoft.AspNetCore.Components;

namespace MealBlazorApp.Components
{
    public abstract class AddComponent<TModel, TView> : ComponentBase where TView : new()
    {
        [CascadingParameter]
        protected BlazoredModalInstance BlazoredModal { get; set; }

        protected TView View { get; set; } = new TView();

        [Inject]
        private IRepository<TModel> Repository { get; set; }

        [Inject]
        private IConverter<TModel, TView> Converter { get; set; }

        public async Task FormSubmitted()
        {
            var model = Converter.Convert(View);
            await Repository.Insert(model);
            await BlazoredModal.CloseAsync(ModalResult.Ok<TModel>(model));
        }
    }

    public abstract class AddComponent<TModel> : ComponentBase where TModel : new()
    {
        [CascadingParameter]
        protected BlazoredModalInstance BlazoredModal { get; set; }

        protected TModel Model { get; set; } = new TModel();

        [Inject]
        private IRepository<TModel> Repository { get; set; }

        public async Task FormSubmitted()
        {
            await Repository.Insert(Model);
            await BlazoredModal.CloseAsync(ModalResult.Ok<TModel>(Model));
        }
    }
}