﻿using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMovimentacaoService
    {
        Task Insert(MovimentacaoDTO movimentacao);
        Task Update(MovimentacaoDTO movimentacao);
        Task<List<MovimentacaoDTO>> GetData();
        Task<List<MovimentacaoDTO>> GetMovimentacoes(int page, int size);
        Task<MovimentacaoDTO> GetMovimentacaoByID(int id);

    }
}
