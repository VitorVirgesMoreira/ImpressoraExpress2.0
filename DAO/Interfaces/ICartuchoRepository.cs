using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface ICartuchoRepository
    {
        Task Create(CartuchoDTO cartucho);
        Task<List<CartuchoDTO>> GetData();
    }
}
