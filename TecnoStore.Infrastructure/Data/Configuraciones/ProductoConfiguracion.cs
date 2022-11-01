using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecnoStore.Core.Entities;

namespace TecnoStore.Infrastructure.Data.Configuraciones
{
    internal class ProductoConfiguracion : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable(name: "Productos");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Categoria)
                .WithMany( x => x.Productos)
                .HasForeignKey(x => x.CategoriaId)
                .HasConstraintName("FK_Productos_Categorias_CategoriaId");

            builder.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Stock);

            builder.Property(x => x.Descripcion)
                .HasMaxLength(500);

            builder.Property(x => x.Precio)
                .IsRequired()
                .HasPrecision(10,2);

            var Producto = new Producto
            {
                Id = 1,
                CategoriaId = 1,
                Nombre = "Cable Tipo C",
                Stock = 25,
                Descripcion = "Longitud 25cm",
                Precio = 250,
                FechaCreo = DateTime.Now,
                UsuarioCreo = "Admin"
            };
        }
    }
}
