namespace CVGenerator.Core.Models
{
    public interface IBaseDto<TKey>
    {
        TKey Id { get; set; }
    }
}
