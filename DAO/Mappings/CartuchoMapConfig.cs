using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace DAO.Mappings
{
    public class CartuchoMapConfig: EntityTypeConfiguration<CartuchoDTO>
    {
        public CartuchoMapConfig()
        {
            this.ToTable("CARTUCHOS");
            this.Property(c => c.NomeModelo).HasMaxLength(150);
            this.Property(c => c.CorCartucho).IsRequired().HasColumnName("CARTUCHO");
            
        }
    }
}
