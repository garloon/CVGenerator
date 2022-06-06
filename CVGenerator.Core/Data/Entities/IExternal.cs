namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Интерфейс, используемый для реализации внешних интеграционных свойств 
    /// </summary>
    /// <typeparam name="TExternalKey"></typeparam>
    public interface IExternal<TExternalKey>
    {
        TExternalKey ExternalId { get; set; }
    }
}
