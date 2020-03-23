using BLL.Interfaces;
using DAO;
using DAO.Interfaces;
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
        private readonly IMovimentacaoRespository respository;
        public MovimentacaoService(IMovimentacaoRespository respository)
        {
            this.respository = respository;
        }

        public async Task<List<MovimentacaoDTO>> GetData()
        {
            return await respository.GetData();
        }

        public async Task Insert(MovimentacaoDTO movimentacao)
        {
            List<string> errors = new List<string>();
            if (movimentacao.DataVenda == null)
            {
                base.AddError("DataVenda", "Data de Locação deve ser informada");
            }
            else if (movimentacao.DataVenda > DateTime.Now)
            {
                base.AddError("DataVenda", "Data de Locação não pode ser depois de hoje");

            }

            if (movimentacao.QuantidadeCartucho <= 0)
            {
                base.AddError("QuantidadeCartucho","Quantidade deve ser maior que zero");
            }

            if (movimentacao.ValorTotalOrcamento <= 0)
            {
                base.AddError("ValorTotalOrcamento", "Orçamento muito baixo, essa empresa vai falir.");
            }

            base.CheckErrors();
            await respository.Create(movimentacao);
        }

        public Task Update(MovimentacaoDTO movimentacao)
        {
            throw new NotImplementedException();
        }
    }
}
