namespace CVGenerator.Core.Models
{
    public abstract class BaseDto<TKey> : IBaseDto<TKey>
    {
        public TKey Id { get; set; }
    }
}
