using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Mappings
{
    public class ClienteMapConfig : IEntityTypeConfiguration<ClienteDTO>
    {
        public void Configure(EntityTypeBuilder<ClienteDTO> builder)
        {

            //FLUENT API
            builder.ToTable("CLIENTES");

           builder.Property(c => c.CPF)
                .IsFixedLength()
                .HasMaxLength(14);

            builder.HasIndex(c => c.CPF).IsUnique();

            builder.Property(c => c.DataNascimento)
                .IsRequired() //este is required é opcional pois a convenção
                              //padrão do EF já é tornar uma data obrigatória
                .HasColumnType("date");

            builder.Property(c => c.Email)
                .HasMaxLength(60);

            builder.HasIndex(c => c.Email)
                .IsUnique();

            builder.Property(c => c.Nome)
                .HasMaxLength(50);
        }
    }

}

