using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TecnoStore.Core.Entities.IdentityModels;

namespace TecnoStore.Infrastructure.Data
{
    public class TecnoStoreContext: IdentityDbContext<ApplicationUser>
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
