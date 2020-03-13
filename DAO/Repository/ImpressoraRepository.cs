using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Repository
{
    public class ImpressoraRepository : IImpressoraRepository
    {

        private ExpressDbContext _context;
        public ImpressoraRepository(ExpressDbContext context)
        {
            _context = context;
        }
        public async Task Create(ImpressoraDTO impressora)
        {

            try
            {

                _context.Impressoras.Add(impressora);
                await _context.SaveChangesAsync();
                
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
