﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ClienteDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
    }
}
