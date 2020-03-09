﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpressoraExpressMVC.Models
{
    public class MovimentacaoViewModel
    {
        public int ID { get; set; }
        public int ImpressoraID { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public double ValorTotalOrcamento { get; set; }
    }
}