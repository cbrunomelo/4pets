using Application.Services;
using Application.Services.Contracts;
using DnsClient.Internal;
using Domain.Commands.HistoryCommands;
using Domain.Handlers;
using Domain.Handlers.Contracts;
using Domain.Queries;
using Domain.Queries.CategoryQuerys;
using Domain.Repository;
using Infra.Logger;
using Infra.Repositorys;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class Ioc 
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IHistoryRepository, HistoryRepository>();
            services.AddScoped<IHistoryFieldRepository, HistoryFieldsRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductQuery, ProductRepository>();
            services.AddSingleton<ILoggerRepo, LoggerRepo>();
            services.AddMediatR((cfg) => {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var assembly in assemblies)
                {
                    cfg.RegisterServicesFromAssemblies(assembly);
                }
            });
            return services;
        }
    }
}
