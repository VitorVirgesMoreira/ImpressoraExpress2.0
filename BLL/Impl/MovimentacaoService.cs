using BLL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
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
                errors.Add("Locação deve ser informada");
            }

            if (movimentacao.DataDevolucao < DateTime.Now)
            {
                errors.Add("Cliente não pode alugar pra ontem.");
            }

            if (movimentacao.QuantidadeCartucho <= 0)
            {
                errors.Add("Quantidade deve ser maior que zero");
            }
            //Continuar daqui
            if (movimentacao.ValorTotalOrcamento <= 0)
            {
                errors.Add("Orçamento muito baixo, essa empresa vai falir.");
            }
            base.CheckErrors();

            throw new NotImplementedException();
        }

        public Task Update(MovimentacaoDTO movimentacao)
        {
            throw new NotImplementedException();
        }
    }
}
