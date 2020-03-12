using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Repository
{
    class CartuchoRepository : ICartuchoRepository
    {
        public async Task Create(CartuchoDTO cartucho)
        {
			try
			{
                using (var context = new ExpressDbContext())
                {
                    context.Cartuchos.Add(cartucho);
                    await context.SaveChangesAsync();
                }
            }
			catch (Exception ex)
			{
                if (ex.InnerException != null && ex.InnerException.InnerException.Message.Contains("NomeModelo"))
                {
                    throw new Exception("Nome do modelo já existe");
                }
                throw new Exception("Erro no banco de dados");
            }
        }
    }
}
