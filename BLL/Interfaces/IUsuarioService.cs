using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUsuarioService
    {
        Task Create(UsuarioDTO usuario);
        Task<List<UsuarioDTO>> GetData();
        Task<UsuarioDTO> Authenticate(string email, string password);
    }
}
