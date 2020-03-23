using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IImpressoraRepository
    {
        Task Create(ImpressoraDTO impressora);
        Task<List<ImpressoraDTO>> GetData();
    }
}
