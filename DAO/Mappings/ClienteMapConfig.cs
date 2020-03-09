using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace DAO.Mappings
{
    public class ClienteRepository : EntityTypeConfiguration<ClienteDTO>
    {
        public ClienteRepository()
        {
            //FLUENT API
            this.ToTable("CLIENTES");

            this.Property(c => c.CPF)
                .IsFixedLength()
                .HasMaxLength(14);

            this.HasIndex(c => c.CPF).IsUnique();

            this.Property(c => c.DataNascimento)
                .IsRequired() //este is required é opcional pois a convenção
                              //padrão do EF já é tornar uma data obrigatória
                .HasColumnType("date");

            this.Property(c => c.Email)
                .HasMaxLength(60);

            this.HasIndex(c => c.Email)
                .IsUnique();

            this.Property(c => c.Nome)
                .HasMaxLength(50);
        }
    }

}

