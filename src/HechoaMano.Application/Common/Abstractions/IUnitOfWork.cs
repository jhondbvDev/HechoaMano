namespace HechoaMano.Application.Common.Abstractions;

public interface IUnitOfWork
{
    Task<int> SaveChangeAsync(CancellationToken cancellationToken=default);
}
