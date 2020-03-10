using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace DAO.Mappings
{
    public class MovimentacaoMapConfig: EntityTypeConfiguration<MovimentacaoDTO>
    {
        public MovimentacaoMapConfig()
        {
            this.ToTable("MOVIMENTACAO");
            this.Property(c => c.DataLocacao).IsRequired().HasColumnType("DateTime2");
            this.Property(c => c.DataDevolucao).HasColumnType("DateTime");
                


        }
    }
}
