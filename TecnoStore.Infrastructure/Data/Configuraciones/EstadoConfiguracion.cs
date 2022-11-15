using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecnoStore.Core.Entities;

namespace TecnoStore.Infrastructure.Data.Configuraciones
{
    public class EstadoConfiguracion : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("Estados");
            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Descripcion)
                .IsRequired();

            builder.Property(prop => prop.UsuarioCreo)
                .IsRequired(false);

            builder.Ignore(prop => prop.Estados);
            builder.Ignore(prop => prop.EstadoId);


            var Activo = new Estado
            {
                Id = 1,
                Descripcion = "Activo",
                UsuarioCreo = "Admin",
            };

            var Eliminado = new Estado
            {
                Id = 2,
                Descripcion = "Eliminado",
                UsuarioCreo = "Admin",
            };

            var Agotado = new Estado
            {
                Id = 3,
                Descripcion = "Agotado",
                UsuarioCreo = "Admin",
            };

            var Descontinuado = new Estado
            {
                Id = 4,
                Descripcion = "Descontinuado",
                UsuarioCreo = "Admin",
            };

            builder.HasData(Activo, Eliminado, Agotado, Descontinuado);

        }
    }
}
