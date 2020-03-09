using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpressoraExpressMVC.Models
{
    public class CartuchoViewModel
    {
        public int ID { get; set; }
        public string NomeModelo { get; set; }
        public string Cor { get; set; }
        public double ValorUnitario { get; set; }
    }
}
