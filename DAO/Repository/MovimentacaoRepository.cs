using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task<List<MovimentacaoDTO>> GetData()
        {
            try
            {
                return await _context.Movimentacoes.ToListAsync();
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + "-" + ex.StackTrace);
                throw new Exception("Erro no Banco de dados, contate o administrador");
            }
        }
    }
}
