using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UsuarioRepository: IUsuarioRepository
    {
        public async Task Create(UsuarioDTO usuario)
        {
            try
            {
                using (var context = new ExpressDbContext())
                {
                    context.Usuarios.Add(usuario);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException.Message.Contains("Email"))
                {

                }
                
            }
        }

        public Task<UsuarioDTO> Authenticate(string email, string passaword)
        {
            throw new NotImplementedException();
        }

       
    }

}
