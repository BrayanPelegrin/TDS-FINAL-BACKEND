using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TecnoStore.Core.Entities.IdentityModels;
using TecnoStore.Core.Interfaces;
using TecnoStore.Core.Services;
using TecnoStore.Infrastructure.Data;
using TecnoStore.Infrastructure.Repositories;

public static class RegistroDeServicios
{
    /*UseLazyLoadingProxies()*/
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
        services.AddTransient<ITokenManager<ApplicationUser>, UsuarioServices>();

    }

    public static void AddIdentity(this IServiceCollection services)
    {

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<TecnoStoreContext>()
            .AddDefaultTokenProviders();

    }

}

