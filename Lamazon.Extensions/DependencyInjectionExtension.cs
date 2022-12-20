using Lamazon.DataAccess;
using Lamazon.DataAccess.Abstraction;
using Lamazon.DataAccess.Repositories;
using Lamazon.DomainModels.Entities;
using Lamazon.Services.Abstraction;
using Lamazon.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lamazon.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection RegisterModule(this IServiceCollection services, string connectionString)
        {
            // Connection string
            services.AddDbContext<LamazonDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            // Service registration
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddSingleton<ILocalizationService, LocalizationService>();

            // Repository registration
            services.AddScoped<IRepository<Invoice>, InvoiceRepository>();
            services.AddScoped<IRepository<Order>, OrderRepository>();
            services.AddScoped<IRepository<ProductCategory>, ProductCategoryRepository>();
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IRepository<Role>, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
