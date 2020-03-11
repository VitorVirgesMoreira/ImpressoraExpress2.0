using BLL.Interfaces;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class MovimentacaoService : BaseService, IMovimentacaoService
    {
        public Task<List<MovimentacaoDTO>> GetData()
        {
            throw new NotImplementedException();
        }

        public Task<MovimentacaoDTO> GetMovimentacaoByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MovimentacaoDTO>> GetMovimentacoes(int page, int size)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(MovimentacaoDTO movimentacao)
        {
            List<string> errors = new List<string>();
            if (movimentacao.DataLocacao == null)
            {
                base.AddError("DataLocacao","Locação deve ser informada");
            }

            if (movimentacao.DataDevolucao < DateTime.Now)
            {
                base.AddError("DataDevolucao", "Cliente não pode alugar pra ontem.");
            }

            if (movimentacao.QuantidadeCartucho <= 0)
            {
                base.AddError("QuantidadeCartucho","Quantidade deve ser maior que zero");
            }
            //Continuar daqui
            if (movimentacao.ValorTotalOrcamento <= 0)
            {
                base.AddError("ValorTotalOrcamento", "Orçamento muito baixo, essa empresa vai falir.");
            }

            base.CheckErrors();
            try
            {
                using (ExpressDbContext context = new ExpressDbContext())
                {
                    context.Movimentacoes.Add(movimentacao);
                    await context.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o admnistrador.");
            }
        }

        public Task Update(MovimentacaoDTO movimentacao)
        {
            throw new NotImplementedException();
        }
    }
}
