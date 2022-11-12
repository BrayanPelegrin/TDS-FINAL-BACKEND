using Microsoft.EntityFrameworkCore;

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
