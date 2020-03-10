using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace DAO.Mappings
{
    public class ImpressoraMapConfig : EntityTypeConfiguration<ImpressoraDTO>
    {
        public ImpressoraMapConfig()
        {
            this.ToTable("IMPRESSORA");
            this.Property(c => c.Modelo).HasMaxLength(150).IsRequired().IsUnicode();
            
            
        }
    }
}
