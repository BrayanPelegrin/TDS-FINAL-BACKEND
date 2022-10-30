using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoStore.Infrastructure.Data;

namespace TecnoStore.Infrastructure
{
    public static class RegistroDeServicios
    {
        public static void Servicios(this IServiceCollection servicios, IConfiguration configuration)
        {
            servicios.AddDbContext<TecnoStoreContext>(options => options.UseSqlServer(configuration.GetConnectionString("CadenaSQL")));
        }
    }
}
