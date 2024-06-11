using HechoaMano.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HechoaMano.API.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigration(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
        }
    }
}
