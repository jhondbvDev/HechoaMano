using HechoaMano.Application;
using HechoaMano.Domain.Entities;
using HechoaMano.Domain.Primitives;
using HechoaMano.Domain.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HechoaMano.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
    {
        public DbSet<Product> Products { get; set; }
        private readonly IPublisher _publisher;

        public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options)
        {
            _publisher = publisher ?? throw new ArgumentException(nameof(publisher));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            
            SeedFamily(modelBuilder);
            SeedSubFamily(modelBuilder);
            SeedFamilyType(modelBuilder);
            SeedSize(modelBuilder);
            SeedRegion(modelBuilder);
        }

        public async Task<int> SaveChangeAsync(CancellationToken cancellationToken = new CancellationToken())
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

        private void SeedFamily(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Family>().HasData(new List<Family>() { 
                Family.Create(Guid.NewGuid(), "BOLSO"),
                Family.Create(Guid.NewGuid(), "MONEDERO"),
                Family.Create(Guid.NewGuid(), "PORTAVASO"),
                Family.Create(Guid.NewGuid(), "JUEGO DE COPA"),
                Family.Create(Guid.NewGuid(), "JUEGO BAR BOTELLA"),
                Family.Create(Guid.NewGuid(), "COPA UN TRAGO"),
                Family.Create(Guid.NewGuid(), "COPA TEQUILERA"),
                Family.Create(Guid.NewGuid(), "ESTUCHE"),
                Family.Create(Guid.NewGuid(), "COPA MINI"),
                Family.Create(Guid.NewGuid(), "LLAVERO"),
                Family.Create(Guid.NewGuid(), "ESPEJO"),
                Family.Create(Guid.NewGuid(), "BURBUJA"),
                Family.Create(Guid.NewGuid(), "IMAN"),
                Family.Create(Guid.NewGuid(), "GORRA"),
                Family.Create(Guid.NewGuid(), "CIGARRILLERA"),
                Family.Create(Guid.NewGuid(), "PLATO"),
                Family.Create(Guid.NewGuid(), "DESTAPADOR")});
        }

        private void SeedSubFamily(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubFamily>().HasData(
                SubFamily.Create(Guid.NewGuid(), "PIRAMIDE"),
                SubFamily.Create(Guid.NewGuid(), "TELAR"),
                SubFamily.Create(Guid.NewGuid(), "DOBLE APLIQUE"),
                SubFamily.Create(Guid.NewGuid(), "MEDIA LUNA"),
                SubFamily.Create(Guid.NewGuid(), "CHIVA"),
                SubFamily.Create(Guid.NewGuid(), "SOMBRERO"),
                SubFamily.Create(Guid.NewGuid(), "SERVILLETERO ROMBO"),
                SubFamily.Create(Guid.NewGuid(), "SERVILLETERO MORA"),
                SubFamily.Create(Guid.NewGuid(), "ESTUCHE"),
                SubFamily.Create(Guid.NewGuid(), "SERVILLETERO JUAN VALDES"),
                SubFamily.Create(Guid.NewGuid(), "SERVILLETERO CUNA"),
                SubFamily.Create(Guid.NewGuid(), "UN TRAGO"),
                SubFamily.Create(Guid.NewGuid(), "BARCO COPAS UN TRAGO"),
                SubFamily.Create(Guid.NewGuid(), "FORRO CUERO"),
                SubFamily.Create(Guid.NewGuid(), "COLGAR CUERO"),
                SubFamily.Create(Guid.NewGuid(), "DISEÑO CRISTAL"),
                SubFamily.Create(Guid.NewGuid(), "DISEÑO OPALIZADA"),
                SubFamily.Create(Guid.NewGuid(), "CHIVA BAR MINI"),
                SubFamily.Create(Guid.NewGuid(), "CARRETA BAR MINI"),
                SubFamily.Create(Guid.NewGuid(), "COPA MINI"),
                SubFamily.Create(Guid.NewGuid(), "CORTAUÑA"),
                SubFamily.Create(Guid.NewGuid(), "ESPEJO"),
                SubFamily.Create(Guid.NewGuid(), "DESTAPADOR"),
                SubFamily.Create(Guid.NewGuid(), "PLACA"),
                SubFamily.Create(Guid.NewGuid(), "CUERO"),
                SubFamily.Create(Guid.NewGuid(), "TAGUA MULTICOLOR"),
                SubFamily.Create(Guid.NewGuid(), "COLLAGE"),
                SubFamily.Create(Guid.NewGuid(), "BOTERO"),
                SubFamily.Create(Guid.NewGuid(), "HUEVO"),
                SubFamily.Create(Guid.NewGuid(), "GATO"),
                SubFamily.Create(Guid.NewGuid(), "PUEBLITO PAISA"),
                SubFamily.Create(Guid.NewGuid(), "GUATAPE"),
                SubFamily.Create(Guid.NewGuid(), "PLATOS CERAMICA"),
                SubFamily.Create(Guid.NewGuid(), "MARCO"),
                SubFamily.Create(Guid.NewGuid(), "RECINA"),
                SubFamily.Create(Guid.NewGuid(), "RECTANGULO"),
                SubFamily.Create(Guid.NewGuid(), "FLORES"),
                SubFamily.Create(Guid.NewGuid(), "FINAS"),
                SubFamily.Create(Guid.NewGuid(), "BORDADA"),
                SubFamily.Create(Guid.NewGuid(), "MALLA"),
                SubFamily.Create(Guid.NewGuid(), "TINTERO"),
                SubFamily.Create(Guid.NewGuid(), "METAL")
                );
        }

        private void SeedRegion(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Region>().HasData(
                Region.Create(Guid.NewGuid(), "COLOMBIA"),
                Region.Create(Guid.NewGuid(), "MEDELLIN"),
                Region.Create(Guid.NewGuid(), "CALI"),
                Region.Create(Guid.NewGuid(), "BARRANQUILLA"),
                Region.Create(Guid.NewGuid(), "CARTAGENA"),
                Region.Create(Guid.NewGuid(), "SAN ANDRES"),
                Region.Create(Guid.NewGuid(), "SANTA MARTA "),
                Region.Create(Guid.NewGuid(), "GUATAPE"),
                Region.Create(Guid.NewGuid(), "ARMENIA"),
                Region.Create(Guid.NewGuid(), "GENERAL")
                );
        }

        private void SeedSize(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Size>().HasData(
                Size.Create(Guid.NewGuid(), "GRANDE"),
                Size.Create(Guid.NewGuid(), "PEQUEÑO"),
                Size.Create(Guid.NewGuid(), "No 0"),
                Size.Create(Guid.NewGuid(), "No 1"),
                Size.Create(Guid.NewGuid(), "No 2"),
                Size.Create(Guid.NewGuid(), "No 3"),
                Size.Create(Guid.NewGuid(), "MEDIANO"),
                Size.Create(Guid.NewGuid(), "X2"),
                Size.Create(Guid.NewGuid(), "X3"),
                Size.Create(Guid.NewGuid(), "X4"),
                Size.Create(Guid.NewGuid(), "X6"),
                Size.Create(Guid.NewGuid(), "X5"),
                Size.Create(Guid.NewGuid(), "MINI")
                );
        }

        private void SeedFamilyType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FamilyType>().HasData(
                FamilyType.Create(Guid.NewGuid(), "COLOR"),
                FamilyType.Create(Guid.NewGuid(), "TRADICIONAL")
                );
        }


    }
}
