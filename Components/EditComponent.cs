using System.Threading.Tasks;
using Blazored.Modal;
using Blazored.Modal.Services;
using MealBlazorApp.Services;
using Microsoft.AspNetCore.Components;


namespace MealBlazorApp.Components
{
    public abstract class EditComponent<TModel, TView> : ComponentBase
    {
        [CascadingParameter]
        protected BlazoredModalInstance BlazoredModal { get; set; }

        [Parameter]
        public int Id { get; set; }

        [Inject]
        private IRepository<TModel> repository { get; set; }
        
        [Inject]
        private IConverter<TModel, TView> Converter { get; set; }

        protected TView View { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var model = await repository.GetById(Id);
            View = Converter.Convert(model);
        }

        protected async Task FormSubmitted()
        {
            var model = Converter.Convert(View);
            await repository.Update(Id, model);
            await BlazoredModal.CloseAsync(ModalResult.Ok<TModel>(model));
        }
    }

    public abstract class EditComponent<TModel> : ComponentBase
    {
        [CascadingParameter]
        protected BlazoredModalInstance BlazoredModal { get; set; }

        [Parameter]
        public int Id { get; set; }

        [Inject]
        private IRepository<TModel> Repository { get; set; }

        protected TModel View { get; set; }

        protected async override Task OnInitializedAsync()
        {
            View = await Repository.GetById(Id);
        }

        protected async Task FormSubmitted()
        {
            await Repository.Update(Id, View);
            await BlazoredModal.CloseAsync(ModalResult.Ok<TModel>(View));
        }
    }
}