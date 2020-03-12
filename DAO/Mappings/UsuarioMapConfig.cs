using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace DAO.Mappings
{
    public class UsuarioMapConfig : IEntityTypeConfiguration<UsuarioDTO>
    {
        public void Configure(EntityTypeBuilder<UsuarioDTO> builder)
        {

            builder.ToTable("USUARIO");
            builder.Property(c => c.Senha).HasMaxLength(70).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(100);
            builder.HasIndex(c => c.Email).IsUnique(true).HasName("UQ_USUARIO_EMAIL");

        }
    }
}
