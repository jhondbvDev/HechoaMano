using HechoaMano.API;
using HechoaMano.Infrastructure;
using HechoaMano.Application;
using HechoaMano.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseExceptionHandler("/error");

    app.ApplyMigration();

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}