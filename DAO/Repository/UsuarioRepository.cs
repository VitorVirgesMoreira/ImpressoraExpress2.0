using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
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
                    throw new Exception("O email já foi cadastrado");
                }
                throw new Exception("Erro no banco de dados");
                
            }
            
        }

        public async Task<UsuarioDTO> Authenticate(string email, string passaword)
        {
           using (var ctx = new ExpressDbContext())
            {
                UsuarioDTO usuario = await ctx.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Senha == passaword);
                if (usuario == null)
                {
                    throw new Exception("Email e/ou senha inválidos");
                }
                return usuario;
            }
        }

       
    }

}
