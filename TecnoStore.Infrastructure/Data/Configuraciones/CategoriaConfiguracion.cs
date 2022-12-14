using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecnoStore.Core.Entities;

namespace TecnoStore.Infrastructure.Data.Configuraciones
{
    internal class CategoriaConfiguracion : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable(name: "Categorias");

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Productos)
                .WithOne(x => x.Categoria)
                .HasPrincipalKey(x => x.Id);

            builder.Property(x => x.Descripcion)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(prop => prop.UsuarioCreo)
                .IsRequired(false);

            builder.HasOne(prop => prop.Estado)
               .WithMany(prop => prop.Categorias)
               .OnDelete(DeleteBehavior.NoAction);


            var categoria = new Categoria
            {
                Id = 1,
                Descripcion = "Accesorios",
                FechaCreo = DateTime.Now,
                UsuarioCreo = "Admin",
                EstadoId = 1
            };

            var categoria2 = new Categoria
            {
                Id = 2,
                Descripcion = "Laptops",
                FechaCreo = DateTime.Now,
                UsuarioCreo = "Admin",
                EstadoId = 1
            };

            builder.HasData(categoria, categoria2);

        }
    }
}
