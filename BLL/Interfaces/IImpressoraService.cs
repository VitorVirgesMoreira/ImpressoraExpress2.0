using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IImpressoraService
    {
        Task Insert(ImpressoraDTO impressora);
        Task Update(ImpressoraDTO impressora);
        Task<List<ImpressoraDTO>> GetImpressoras(int page, int size);
        Task<ImpressoraDTO> GetImpressoraByID(int id);
    }
}
