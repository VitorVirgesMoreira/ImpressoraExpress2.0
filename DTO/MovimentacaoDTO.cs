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
        public int ClienteID { get; set; }
        public virtual ClienteDTO Clientes{ get; set; }
        public int CartuchoID { get; set; }
        public virtual CartuchoDTO Cartuchos{ get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public int QuantidadeCartucho { get; set; }
        public double ValorTotalOrcamento { get; set; }
    }
}
