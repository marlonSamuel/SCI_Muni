using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBaseContext.Config
{
    class DetalleCompraConfig
    {
        public DetalleCompraConfig(EntityTypeBuilder<DetalleCompra> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Cantidad).IsRequired();
            entityBuilder.Property(x => x.Precio_Compra).IsRequired();
        }
    }
}
