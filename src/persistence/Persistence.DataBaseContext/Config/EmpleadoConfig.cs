using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBaseContext.Config
{
    class EmpleadoConfig
    {
        public EmpleadoConfig(EntityTypeBuilder<Empleado> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Primer_nombre).IsRequired().HasMaxLength(25);
            entityBuilder.Property(x => x.Segundo_nombre).HasMaxLength(25);
            entityBuilder.Property(x => x.Primer_apellido).IsRequired().HasMaxLength(25);
            entityBuilder.Property(x => x.Segundo_apellido).HasMaxLength(25);
            entityBuilder.Property(x => x.Direccion).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Telefono).IsRequired().HasMaxLength(25);
            entityBuilder.Property(x => x.Email).HasMaxLength(100);
            entityBuilder.Property(x => x.Foto).HasMaxLength(25);
        }
    }
}
