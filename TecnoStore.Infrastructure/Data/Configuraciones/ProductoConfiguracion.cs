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
                .WithMany(x => x.Productos)
                .HasForeignKey(x => x.CategoriaId)
                .HasConstraintName("FK_Productos_Categorias_CategoriaId");

            builder.HasOne(prop => prop.Estado)
                .WithMany(prop => prop.Productos)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Stock);

            builder.Property(x => x.Descripcion)
                .HasMaxLength(500);

            builder.Property(x => x.Precio)
                .IsRequired()
                .HasPrecision(10,2);

            builder.Property(prop => prop.UsuarioCreo)
                .IsRequired(false);

            var Producto = new Producto
            {
                Id = 1,
                CategoriaId = 1,
                Nombre = "Cable Tipo C",
                Stock = 30,
                Descripcion = "Longitud 25cm",
                Precio = 250,
                FechaCreo = DateTime.Now,
                UsuarioCreo = "Admin",
                EstadoId = 1
            };

            var producto2 = new Producto
            {
                Id = 2,
                CategoriaId = 1,
                Nombre = "Beats Solo3 Wiriless",
                Stock = 10,
                Descripcion = "40 horas de reproduccion continua, Audio 8D, BassBost",
                Precio = 7849.99m,
                FechaCreo = DateTime.Now,
                UsuarioCreo = "Admin",
                EstadoId = 1
            };

            var producto3 = new Producto
            {
                Id = 3,
                CategoriaId = 1,
                Nombre = "Razer Gaming Viper",
                Stock = 25,
                Descripcion = "Mouse inalámbrico con sensor óptico DPI de entrada más rápida",
                Precio = 1249.99m,
                FechaCreo = DateTime.Now,
                UsuarioCreo = "Admin",
                EstadoId = 1
            };

            var producto4 = new Producto
            {
                Id = 4,
                CategoriaId = 2,
                Nombre = "Apple MacBook Air 2020",
                Stock = 25,
                Descripcion = "chip Apple M1, pantalla Retina de 13 pulgadas, 8 GB de RAM, almacenamiento SSD de 256 GB",
                Precio = 1249.99m,
                FechaCreo = DateTime.Now,
                UsuarioCreo = "Admin",
                EstadoId = 1
            };

            var producto5 = new Producto
            {
                Id = 5,
                CategoriaId = 2,
                Nombre = "ASUS TUF Dash F15 2022",
                Stock = 25,
                Descripcion = "FHD de 15.6 pulgadas 144Hz, Intel 10-Core i7-12650H, GeForce RTX 3070, DDR5 de 32 GB, SSD PCIe de 1 TB",
                Precio = 79999.99m,
                FechaCreo = DateTime.Now,
                UsuarioCreo = "Admin",
                EstadoId = 1
            };

            var producto6 = new Producto
            {
                Id = 6,
                CategoriaId = 2,
                Nombre = "Dell Laptop XPS 13 9310",
                Stock = 25,
                Descripcion = "Pantalla táctil, pantalla UHD+ de 13.4 pulgadas, delgada y ligera, Intel Core i7-1195G7, 16GB LPDDR4x RAM, 512GB SSD",
                Precio = 66729.99m,
                FechaCreo = DateTime.Now,
                UsuarioCreo = "Admin",
                EstadoId = 1
            };

            builder.HasData(Producto, producto2, producto3, producto4, producto5, producto6);

        }
    }
}
