using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ImpressoraDTO
    {
        public int ID { get; set; }
        public string Modelo { get; set; }
        public double ValorTotal { get; set; }
        public double ValorTotalLocacao { get; set; }
        public bool ImpressorasDisponiveis { get; set; }
        public virtual ICollection<MovimentacaoDTO> Movimentacoes { get; set; }
    }
}
