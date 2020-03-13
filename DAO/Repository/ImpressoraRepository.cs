using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Repository
{
    class ImpressoraRepository : IImpressoraRepository
    {
        public async Task Create(ImpressoraDTO impressora)
        {

            try
            {
                using (var context = new ExpressDbContext())
                {
                    context.Impressoras.Add(impressora);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException.Message.Contains("Modelo"))
                {
                    throw new Exception("Nome do modelo já existe");
                }
                throw new Exception("Erro no banco de dados");
            }
        }
    }
}
