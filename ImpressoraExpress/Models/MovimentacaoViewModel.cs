using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpressoraExpressMVC.Models
{
    public class MovimentacaoViewModel
    {
        public int ID { get; set; }
        public int ImpressoraID { get; set; }
        public  ImpressoraDTO Impressora { get; set; }
        public int ClienteID { get; set; }
        public  ClienteDTO Cliente { get; set; }
        public int CartuchoID { get; set; }
        public  CartuchoDTO Cartucho { get; set; }
        public DateTime DataVenda { get; set; }
        public int QuantidadeCartucho { get; set; }
        public double ValorTotalOrcamento { get; set; }

    }
}
