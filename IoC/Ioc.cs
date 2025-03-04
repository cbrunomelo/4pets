using Application.Services;
using Application.Services.Contracts;
using AutoMapper;
using Domain.Queries;
using Domain.Repository;
using Infra.Logger;
using Infra.Repositorys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Ioc 
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration _configuration)
    {
        #region Repositories
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<IHistoryRepository, HistoryRepository>();
        services.AddScoped<IHistoryFieldRepository, HistoryFieldsRepository>();
        services.AddScoped<IStockRepository, StockRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductQuery, ProductRepository>();
        #endregion

        #region Handlers
        #endregion

        #region Services
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IProductService, ProductService>();

        #endregion

        #region Dictionary
        #endregion

        #region Helper
        services.AddSingleton<ILoggerRepo>(provider => new LoggerRepo(_configuration.GetConnectionString("Mongo")));
        services.AddMediatR((cfg) => {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                cfg.RegisterServicesFromAssemblies(assembly);
            }
        });
        #endregion


        return services;
    }
}
