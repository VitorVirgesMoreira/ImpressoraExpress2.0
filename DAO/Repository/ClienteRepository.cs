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
        public async Task Create(ClienteDTO cliente)
        {
            try
            {
                using (var context = new ExpressDbContext())
                {
                    context.Clientes.Add(cliente);
                    await context.SaveChangesAsync();
                }
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
