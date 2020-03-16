using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Mappings
{
    public class CartuchoMapConfig : IEntityTypeConfiguration<CartuchoDTO>
    {
        public void Configure(EntityTypeBuilder<CartuchoDTO> builder)
        {
                builder.ToTable("CARTUCHOS");
                builder.Property(c => c.NomeModelo).HasMaxLength(150).IsUnicode();
                builder.Property(c => c.CorCartucho).IsRequired().HasColumnName("CARTUCHO");

           
        }
    }
}
