using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBaseContext.Config
{
    class ApplicationUserConfig
    {
        public ApplicationUserConfig(EntityTypeBuilder<ApplicationUser> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Foto).HasMaxLength(100);
        }
    }
}
