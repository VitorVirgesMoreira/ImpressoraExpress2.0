using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private ExpressDbContext _context;
        public ClienteRepository(ExpressDbContext context)
        {
            _context = context;
        }
        public async Task Create(ClienteDTO cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                    await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                if (ex.InnerException != null && ex.InnerException.InnerException.Message.Contains("Email"))
                {
                    throw new Exception("Esse email ja possui cadaastro");
                }
                throw new Exception("Erro no banco de dados");

            }
     

        }
      
    }
}
