using HechoaMano.Application;
using HechoaMano.Domain.Primitives;
using HechoaMano.Domain.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HechoaMano.Infrastructure.Persistence
{
    public class ApplicationDbContext :DbContext,IApplicationDbContext,IUnitOfWork
    {
        public DbSet<Product> Products { get; set; }
        private readonly IPublisher _publisher;

        public ApplicationDbContext(DbContextOptions options , IPublisher publisher ):base(options)
        {
               _publisher = publisher?? throw new ArgumentException(nameof(publisher));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public  async Task<int> SaveChangeAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var domainEvents = ChangeTracker.Entries<AggregateRoot>()
                .Select(x => x.Entity)
                .Where(x => x.DomainEvents.Any())
                .SelectMany(x => x.DomainEvents);

            var result = await base.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }

            return result;
                
        }

       
    }
}
