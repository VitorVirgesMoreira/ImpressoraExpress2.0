using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICartuchoService
    {
        Task Insert(CartuchoDTO cartucho);
        Task Update(CartuchoDTO cartucho);
        Task<List<CartuchoDTO>> GetCartuchos(int page, int size);
        Task<CartuchoDTO> GetCartuchoByID(int id);
    }
}
