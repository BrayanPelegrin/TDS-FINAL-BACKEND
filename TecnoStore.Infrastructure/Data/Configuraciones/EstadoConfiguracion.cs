using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoStore.Core.Entities;

namespace TecnoStore.Infrastructure.Data.Configuraciones
{
    public class EstadoConfiguracion : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
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

            };

            var Eliminado = new Estado
            {
                Id = 2,
                Descripcion = "Eliminado",

            };

            var Agotado = new Estado
            {
                Id = 3,
                Descripcion = "Agotado",

            };

            var Descontinuado = new Estado
            {
                Id = 4,
                Descripcion = "Descontinuado",

            };

            builder.HasData(Activo, Eliminado, Agotado, Descontinuado);

        }
    }
}
