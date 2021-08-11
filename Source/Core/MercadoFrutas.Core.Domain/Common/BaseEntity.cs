namespace MercadoFrutas.Core.Domain.Common
{
    public abstract class BaseEntity<TId>
        where TId : struct
    {
        public virtual TId Id { get; protected set; }
    }
}