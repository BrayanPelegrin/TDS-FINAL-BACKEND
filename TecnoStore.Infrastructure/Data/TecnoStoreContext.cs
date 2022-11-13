using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TecnoStore.Infrastructure.Data
{
    public class TecnoStoreContext: IdentityDbContext
    {
        public TecnoStoreContext()
        {

        }

        public TecnoStoreContext(DbContextOptions<TecnoStoreContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TecnoStoreContext).Assembly);
        }
    }
}
