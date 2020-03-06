using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class CartuchoDTO
    {
        public int ID { get; set; }
        public string NomeModelo { get; set; }
        public string Cor { get; set; }
        public int Quantidade { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorTotalOrcamento { get; set; }
    }
}
