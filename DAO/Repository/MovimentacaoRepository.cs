using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Repository
{
    public class MovimentacaoRepository : IMovimentacaoRespository
    {
        private ExpressDbContext _context;
        public MovimentacaoRepository(ExpressDbContext context)
        {
            _context = context;
        }
        public async Task Create(MovimentacaoDTO movimentacao)
        {
            try
            {

                _context.Movimentacoes.Add(movimentacao);
                    await _context.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException.Message.Contains("ImpressoraID"))
                {
                    throw new Exception("ID nao cadastrado");
                }
                throw new Exception("Erro no banco de dados");
            }
        }
    }
}
