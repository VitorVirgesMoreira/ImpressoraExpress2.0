using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IMovimentacaoRespository
    {
        Task Create(MovimentacaoDTO movimentacao);
        Task<List<MovimentacaoDTO>> GetData();

    }
}
