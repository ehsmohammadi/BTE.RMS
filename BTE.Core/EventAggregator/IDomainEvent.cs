namespace BTE.Core
{
    public interface IDomainEvent<T>
    {
        bool SameEventAs(T other);
    }
}
