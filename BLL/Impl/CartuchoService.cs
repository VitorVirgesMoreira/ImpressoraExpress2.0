using BLL.Interfaces;
using Common;
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
    public class CartuchoService : BaseService, ICartuchoService
    {
        private readonly ICartuchoRepository repository;

        //Colocar Validações nesse service enos abaixos
        public CartuchoService(ICartuchoRepository repository)
        {
            this.repository = repository;
        }

        public async Task Insert(CartuchoDTO cartucho)
        {
            List<Error> errors = new List<Error>();
            if (string.IsNullOrWhiteSpace(cartucho.NomeModelo))
            {
                base.AddError("NomeModelo", "Nome do modelo deve ser informado");
            }
            else if (cartucho.NomeModelo.Length < 5 || cartucho.NomeModelo.Length > 150)
            {
                base.AddError("NomeModelo", "O nome do modelo deve conter entre 5 e 150 caracteres");
            }


            if (cartucho.ValorUnitario < 30)
            {
                base.AddError("ValorUnitario", "Valor de unidade deve ser maior que R$30,00.");
            }
            base.CheckErrors();

            await repository.Create(cartucho);

        }

        public Task Update(CartuchoDTO cartucho)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CartuchoDTO>> GetCartuchos()
        {
            return await repository.GetCartuchos();
        }

        public async Task<List<CartuchoDTO>> GetData()
        {
            return await repository.GetData();
        }
    }
}
