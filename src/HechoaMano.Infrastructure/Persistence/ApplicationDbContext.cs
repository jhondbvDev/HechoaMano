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
                Family.Create(Guid.Parse("791ea326-1110-4952-b6a9-b5c1762e1fb0"), "BOLSO"),
                Family.Create(Guid.Parse("a5a5d59e-05d2-48c3-bf8c-77d9c3a342ec"), "MONEDERO"),
                Family.Create(Guid.Parse("5a5b20cc-ab3a-4c1f-89ce-ee7b8671c67b"), "PORTAVASO"),
                Family.Create(Guid.Parse("782fcf19-4c25-4c71-8af0-fce32fd5ecde"), "JUEGO DE COPA"),
                Family.Create(Guid.Parse("c6c7f7ef-4667-4667-9264-c2419685039d"), "JUEGO BAR BOTELLA"),
                Family.Create(Guid.Parse("f9a82640-55d0-4397-92b4-231c253de55c"), "COPA UN TRAGO"),
                Family.Create(Guid.Parse("e6598dca-0faa-4655-a7ab-49843e8e4189"), "COPA TEQUILERA"),
                Family.Create(Guid.Parse("55eee6be-64b1-4066-84b5-8599d4bfdb07"), "ESTUCHE"),
                Family.Create(Guid.Parse("311c88c1-f1e9-444a-9db8-315d30bbd4f3"), "COPA MINI"),
                Family.Create(Guid.Parse("979a8121-0aee-495c-aaf3-659475b4f5e4"), "LLAVERO"),
                Family.Create(Guid.Parse("734ffdbd-7825-42a5-91c0-34e432f9b046"), "ESPEJO"),
                Family.Create(Guid.Parse("dfee3615-a13a-4873-bcc0-ea8899f1fef1"), "BURBUJA"),
                Family.Create(Guid.Parse("17a7f4e9-8b04-4bf7-bb1d-a6ef058052df"), "IMAN"),
                Family.Create(Guid.Parse("9cbce495-90e9-4958-8a4f-cb0705f8dd0e"), "GORRA"),
                Family.Create(Guid.Parse("8aaf977d-a876-49c5-8005-1e0eca0205f1"), "CIGARRILLERA"),
                Family.Create(Guid.Parse("77d8eedd-173f-4259-b74e-0b0af1b70561"), "PLATO"),
                Family.Create(Guid.Parse("9aa075c1-8da7-46e0-bbbe-eed2d0f2515f"), "DESTAPADOR")});
        }

        private void SeedSubFamily(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubFamily>().HasData(
                SubFamily.Create(Guid.Parse("d52044c1-6fa7-496b-8deb-204cb124f12c"), "PIRAMIDE"),
                SubFamily.Create(Guid.Parse("a6db5cfa-1b5c-44a9-9b94-5aa19c809cbd"), "TELAR"),
                SubFamily.Create(Guid.Parse("b25a7cce-87fd-4679-a93b-99f507e63418"), "DOBLE APLIQUE"),
                SubFamily.Create(Guid.Parse("4c95de06-d202-4649-91cb-578e8d71b5fa"), "MEDIA LUNA"),
                SubFamily.Create(Guid.Parse("e582ccfe-8f6f-41b2-b4e3-562c8b961ba2"), "CHIVA"),
                SubFamily.Create(Guid.Parse("3354f67e-f863-4403-b064-233ed7975ab7"), "SOMBRERO"),
                SubFamily.Create(Guid.Parse("8fda733b-bbf8-428f-b448-21125c0ca6c8"), "SERVILLETERO ROMBO"),
                SubFamily.Create(Guid.Parse("e41f4ff9-4b66-47f0-bd16-148faecf1a4a"), "SERVILLETERO MORA"),
                SubFamily.Create(Guid.Parse("0954cf7b-551e-4ea7-af6d-480d5565e974"), "ESTUCHE"),
                SubFamily.Create(Guid.Parse("5d0b3852-1aa8-4bd6-8562-81fb591b53d8"), "SERVILLETERO JUAN VALDES"),
                SubFamily.Create(Guid.Parse("b79832af-48e5-4309-917e-d58bcc79254d"), "SERVILLETERO CUNA"),
                SubFamily.Create(Guid.Parse("52b07f65-a126-4150-b7e0-0ded5b6b3a9a"), "UN TRAGO"),
                SubFamily.Create(Guid.Parse("638d96e8-d303-4c2c-b645-89f58594f64c"), "BARCO COPAS UN TRAGO"),
                SubFamily.Create(Guid.Parse("1ffa24ea-5fc4-45a3-b65e-f9cc0805e193"), "FORRO CUERO"),
                SubFamily.Create(Guid.Parse("eecff842-c38b-40ce-b7c5-24fffdfdf133"), "COLGAR CUERO"),
                SubFamily.Create(Guid.Parse("57e9568a-3ced-4379-b0b8-539898d954ef"), "DISEÑO CRISTAL"),
                SubFamily.Create(Guid.Parse("0c5934ac-c5f2-4d76-b099-ec58ab3dd78e"), "DISEÑO OPALIZADA"),
                SubFamily.Create(Guid.Parse("ee4ae14c-664b-4743-af9b-214496dbe4b4"), "CHIVA BAR MINI"),
                SubFamily.Create(Guid.Parse("0421e866-ff74-4a0a-a022-885d85bcfc22"), "CARRETA BAR MINI"),
                SubFamily.Create(Guid.Parse("dcbc0be6-0650-454d-be30-e23446c5e3a8"), "COPA MINI"),
                SubFamily.Create(Guid.Parse("e06eae6b-73b5-4000-8a5f-74a703c258bd"), "CORTAUÑA"),
                SubFamily.Create(Guid.Parse("d3de0d9c-c42b-4ef9-b514-830967f15560"), "ESPEJO"),
                SubFamily.Create(Guid.Parse("aa85c690-a984-43ae-b67f-c699f7454503"), "DESTAPADOR"),
                SubFamily.Create(Guid.Parse("987924b7-9829-4721-84c2-e31676da9f82"), "PLACA"),
                SubFamily.Create(Guid.Parse("5a55df02-3667-45f2-9466-9e68a27283f0"), "CUERO"),
                SubFamily.Create(Guid.Parse("861c8747-0b32-4139-8ffc-669ca8b7c9ff"), "TAGUA MULTICOLOR"),
                SubFamily.Create(Guid.Parse("4daba243-31d9-4b52-91c7-d34523c98a35"), "COLLAGE"),
                SubFamily.Create(Guid.Parse("67abcc4d-e158-41ea-9941-d30df062c785"), "BOTERO"),
                SubFamily.Create(Guid.Parse("d81b19c6-578b-47ac-b8cf-71832f9ce296"), "HUEVO"),
                SubFamily.Create(Guid.Parse("7096db25-29fc-4719-8305-e307e36ad2d5"), "GATO"),
                SubFamily.Create(Guid.Parse("3402719e-fec2-485b-8cf5-f4a78911ad7b"), "PUEBLITO PAISA"),
                SubFamily.Create(Guid.Parse("6be8f6d2-2708-4c8b-bfdc-c6fbbeb6c48d"), "GUATAPE"),
                SubFamily.Create(Guid.Parse("acfb1398-bbc1-427e-b6c3-52a4f5f92f02"), "PLATOS CERAMICA"),
                SubFamily.Create(Guid.Parse("459fb84d-cd4c-45c7-9858-7eeb9ea3eb0f"), "MARCO"),
                SubFamily.Create(Guid.Parse("ee135c7d-3635-4161-a97c-065165589866"), "RECINA"),
                SubFamily.Create(Guid.Parse("c8be2ada-2a7f-4996-891e-41ef6d4ba0bf"), "RECTANGULO"),
                SubFamily.Create(Guid.Parse("a64e0faa-f323-4542-b69a-b02a5bd52e0a"), "FLORES"),
                SubFamily.Create(Guid.Parse("21ddd364-1028-4020-ac27-e02d3cb80552"), "FINAS"),
                SubFamily.Create(Guid.Parse("de1efbd5-07c5-48ae-88a6-837ab750b471"), "BORDADA"),
                SubFamily.Create(Guid.Parse("74afd2e9-729a-4175-b4f4-8bced0820b31"), "MALLA"),
                SubFamily.Create(Guid.Parse("89acacbb-bda9-4882-91c6-51619e23691c"), "TINTERO"),
                SubFamily.Create(Guid.Parse("c46c694a-fab4-462b-ae7b-a23f8f53d58a"), "METAL")
                );
        }

        private void SeedRegion(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Region>().HasData(
                Region.Create(Guid.Parse("da663528-86f4-422a-badb-da8ca9b6b720"), "COLOMBIA"),
                Region.Create(Guid.Parse("be0cac98-67dd-4e1e-b61e-a68b7995f251"), "MEDELLIN"),
                Region.Create(Guid.Parse("6b1c12fb-75a0-4740-aba1-2242eff9f1f1"), "CALI"),
                Region.Create(Guid.Parse("ef5cabc2-f7a5-4967-ac14-99e6c008307b"), "BARRANQUILLA"),
                Region.Create(Guid.Parse("c77c3a42-5228-4660-869c-551c5ea74ddd"), "CARTAGENA"),
                Region.Create(Guid.Parse("9de4f31d-53b3-406f-8551-469708b0f614"), "SAN ANDRES"),
                Region.Create(Guid.Parse("4fba73e9-c904-4cbf-86eb-625fc3e86225"), "SANTA MARTA "),
                Region.Create(Guid.Parse("7a927084-d92d-4f05-b692-08176b8daf5d"), "GUATAPE"),
                Region.Create(Guid.Parse("2669b589-1183-4d04-9c8b-8c3d9e992b48"), "ARMENIA"),
                Region.Create(Guid.Parse("fa99f2fb-073f-4bf7-834d-ed9b55e8759e"), "GENERAL")
                );
        }

        private void SeedSize(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Size>().HasData(
                Size.Create(Guid.Parse("a846a3ec-8ad7-473f-9107-81169cedf740"), "GRANDE"),
                Size.Create(Guid.Parse("470a16c8-e584-4f1f-85c5-04b07a87471e"), "PEQUEÑO"),
                Size.Create(Guid.Parse("a015c766-3c91-4904-a7ac-bd54be7f4121"), "No 0"),
                Size.Create(Guid.Parse("a487b028-b61a-4b80-94fb-65242878eaee"), "No 1"),
                Size.Create(Guid.Parse("8d4eab22-900b-489c-91fa-ed9fe695cbd6"), "No 2"),
                Size.Create(Guid.Parse("c123e369-172e-41ca-b3b8-a6a6c30724ff"), "No 3"),
                Size.Create(Guid.Parse("eaf3733b-85d6-4911-ae70-13820d431c80"), "MEDIANO"),
                Size.Create(Guid.Parse("5e7de310-e9ca-4b58-908c-31b3b6412495"), "X2"),
                Size.Create(Guid.Parse("de79c6d2-c572-4391-aa77-210056c8f9f7"), "X3"),
                Size.Create(Guid.Parse("e1bfaa2f-a5aa-43c4-bdbe-617cd254cdbb"), "X4"),
                Size.Create(Guid.Parse("05a34005-8a4c-420e-84bf-d04fcb747502"), "X6"),
                Size.Create(Guid.Parse("5ed80180-fa8c-4c74-93bd-edfab30154b2"), "X5"),
                Size.Create(Guid.Parse("a37ea663-7a40-4abb-9bc2-e6e3d4016f66"), "MINI")
                );
        }

        private void SeedFamilyType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FamilyType>().HasData(
                FamilyType.Create(Guid.Parse("070a6b5b-17af-46a7-b02d-48a60a6b93a6"), "COLOR"),
                FamilyType.Create(Guid.Parse("06f06c09-87d9-4395-905c-c3372d8d9968"), "TRADICIONAL")
                );
        }
    }
}
