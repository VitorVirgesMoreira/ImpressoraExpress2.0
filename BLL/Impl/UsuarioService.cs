using BLL.Interfaces;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        UsuarioRepository repository = new UsuarioRepository();

        public async Task Create(UsuarioDTO usuario)
        {

            await repository.Create(usuario);

        }

        public async Task<UsuarioDTO> Authenticate(string email, string password)
        {
            return await repository.Authenticate(email, password);
        }

    }
}
