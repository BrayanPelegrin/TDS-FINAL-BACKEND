using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TecnoStore.Core.DTOs;
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
        services.AddTransient<ITokenManager<UsuarioDTO>, UsuarioServices>();

    }

    public static void AddIdentity(this IServiceCollection services)
    {

        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<TecnoStoreContext>()
            .AddDefaultTokenProviders();

    }

}

