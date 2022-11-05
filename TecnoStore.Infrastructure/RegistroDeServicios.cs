using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TecnoStore.Core.Interfaces;
using TecnoStore.Infrastructure.Data;
using TecnoStore.Infrastructure.Repositories;

public static class RegistroDeServicios
    {
        public static void AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TecnoStoreContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CadenaSQL"));
            });
        }

        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(RepositorioBase<>));
        }
    }

