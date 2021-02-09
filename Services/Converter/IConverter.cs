namespace MealBlazorApp.Services
{
    interface IConverter<TModel, TView>
    {
        TView Convert(TModel model);
        TModel Convert(TView view);
    }
}