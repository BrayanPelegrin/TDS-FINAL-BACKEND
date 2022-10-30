using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TecnoStore.Infrastructure.Data
{
    public class TecnoStoreContext: DbContext
    {
        public TecnoStoreContext()
        {

        }

        public TecnoStoreContext(DbContextOptions<TecnoStoreContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TecnoStoreContext).Assembly);
        }
    }
}
