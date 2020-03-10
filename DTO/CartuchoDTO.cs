using DTO.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class CartuchoDTO
    {
        public int ID { get; set; }
        public string NomeModelo { get; set; }
        public Cor  CorCartucho { get; set; }
        public double ValorUnitario { get; set; }
    }
}
