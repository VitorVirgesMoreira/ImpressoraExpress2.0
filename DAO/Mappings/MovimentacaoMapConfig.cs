using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Mappings
{
    public class MovimentacaoMapConfig : IEntityTypeConfiguration<MovimentacaoDTO>
    {
        public void Configure(EntityTypeBuilder<MovimentacaoDTO> builder)
        {
            builder.ToTable("MOVIMENTACAO");
            builder.Property(c => c.DataLocacao).IsRequired().HasColumnType("DateTime2");
            builder.Property(c => c.DataDevolucao).HasColumnType("DateTime");
        }
    }
}
