using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private ExpressDbContext _context;
        public UsuarioRepository(ExpressDbContext context)
        {
            _context = context;
        }
        public async Task Create(UsuarioDTO usuario)
        {
            try
            {

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

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

            UsuarioDTO usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Senha == passaword);
            if (usuario == null)
            {
                throw new Exception("Email e/ou senha inválidos");
            }
            return usuario;

        }

        public async Task<List<UsuarioDTO>> GetData()
        {
            try
            {
                return await _context.Usuarios.ToListAsync();
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + "-" + ex.StackTrace);
                throw new Exception("Erro no Banco de dados, contate o administrador");
            }
        }
    }

}
