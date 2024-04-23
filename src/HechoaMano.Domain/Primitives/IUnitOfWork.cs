namespace HechoaMano.Domain.Primitives
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangeAsync(CancellationToken cancellationToken=default);
    }
}
