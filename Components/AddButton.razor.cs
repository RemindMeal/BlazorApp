using System.Threading.Tasks;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;

namespace MealBlazorApp.Components
{
    public partial class AddButton<TAdd> where TAdd : ComponentBase
    {
        [Parameter]
        public EventCallback Callable { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Inject]
        private IModalService Modal { get; set; }

        private async Task Add()
        {
            var mealModal = Modal.Show<TAdd>(Title);
            var result = await mealModal.Result;

            if (!result.Cancelled)
            {
                await Callable.InvokeAsync();
            }
        }
    }
}
