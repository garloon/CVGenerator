namespace CVGenerator.Core.Services.Interfaces
{
    public interface IRazorRendererService
    {
        string RenderPartialToString<TModel>(string pageName, TModel model);
    }
}
