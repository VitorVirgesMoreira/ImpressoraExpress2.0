using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Mappings
{
    public class ImpressoraMapConfig : IEntityTypeConfiguration<ImpressoraDTO>
    {
        public void Configure(EntityTypeBuilder<ImpressoraDTO> builder)
        {
            builder.ToTable("IMPRESSORA");
            builder.Property(c => c.Modelo).HasMaxLength(150).IsRequired().IsUnicode();

        }
    }
}
