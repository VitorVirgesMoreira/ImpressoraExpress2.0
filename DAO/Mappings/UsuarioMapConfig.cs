using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace DAO.Mappings
{
    public class UsuarioMapConfig: EntityTypeConfiguration<UsuarioDTO>
    {
        public UsuarioMapConfig()
        {
            this.ToTable("USUARIO");
            this.Property(c => c.Senha).HasMaxLength(70).IsRequired();
            this.Property(c => c.Email).HasMaxLength(100);
            this.HasIndex(c => c.Email).IsUnique(true).HasName("UQ_USUARIO_EMAIL");
            
        }
    }
}
