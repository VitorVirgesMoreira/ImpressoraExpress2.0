using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IClienteRepository
    {
        Task Create(ClienteDTO cliente);
        Task<List<ClienteDTO>> GetData();
    }
}
