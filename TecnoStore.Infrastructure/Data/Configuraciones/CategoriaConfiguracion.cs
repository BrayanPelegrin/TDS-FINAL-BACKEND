﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                .WithOne(x => x.Categoria);

            builder.Property(x => x.Descripcion)
                .HasMaxLength(100)
                .IsRequired();

            
        }
    }
}