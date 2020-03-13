using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Repository
{
    class MovimentacaoRepository : IMovimentacaoRespository
    {
        public async Task Create(MovimentacaoDTO movimentacao)
        {
            try
            {
                using (var context = new ExpressDbContext())
                {
                    context.Movimentacoes.Add(movimentacao);
                    await context.SaveChangesAsync();
                }
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
