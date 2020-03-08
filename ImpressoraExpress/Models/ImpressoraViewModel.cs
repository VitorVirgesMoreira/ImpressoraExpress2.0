using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpressoraExpressMVC.Models
{
    public class ImpressoraViewModel
    {
        public int ID { get; set; }
        public string Modelo { get; set; }
        public double ValorTotal { get; set; }
        public double ValorTotalLocacao { get; set; }
        public bool ImpressorasDisponiveis { get; set; }
        public int MovimentacoesID { get; set; }
    }
}
