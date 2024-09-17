using WebShop.Infrastructure.Seeders;
using WebShopProject.Infrastructure.Extension;
using WebShopProject.Application.Extensions;
using WebShop.API.ErrorHandling;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IDataSeeder>();
await seeder.Seed();

// Configure the HTTP request pipeline.

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
