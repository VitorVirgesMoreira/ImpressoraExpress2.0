using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class MovimentacaoDTO
    {
        public int ID { get; set; }
        public int ImpressoraID { get; set; }
        public virtual ImpressoraDTO Impressora { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public double ValorTotalOrcamento { get; set; }
    }
}
