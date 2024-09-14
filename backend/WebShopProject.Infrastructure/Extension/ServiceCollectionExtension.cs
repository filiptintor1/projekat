using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Domain.Entities;
using WebShop.Domain.Repositories;
using WebShop.Infrastructure.Repositories;
using WebShop.Infrastructure.Seeders;
using WebShopProject.Infrastructure.Database;


namespace WebShopProject.Infrastructure.Extension;

public static class ServiceCollectionExtension
{

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("WebShopProjectDb");
        services.AddDbContext<ProjectDbContext>(options =>
        options
        .UseSqlServer(connectionString)
        .EnableSensitiveDataLogging());

        services.AddScoped<IDataSeeder, DataSeeder>();

        services.AddScoped<IProductsRepository, ProductsRepository>();
    }

}
