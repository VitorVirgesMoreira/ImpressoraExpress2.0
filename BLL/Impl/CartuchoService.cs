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
        public Task<CartuchoDTO> GetCartuchoByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CartuchoDTO>> GetCartuchos(int page, int size)
        {
            throw new NotImplementedException();
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
            //try
            //{
            //    using (ExpressDbContext context = new ExpressDbContext())
            //    {
            //        context.Cartuchos.Add(cartucho);
            //        await context.SaveChangesAsync();

            //    }
            //}
            //catch (Exception ex)
            //{
            //    File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
            //    throw new Exception("Erro no banco de dados, contate o admnistrador.");
            //}
            await repository.Create(cartucho);

        }

        public Task Update(CartuchoDTO cartucho)
        {
            throw new NotImplementedException();
        }

        System.Threading.Tasks.Task<CartuchoDTO> ICartuchoService.GetCartuchoByID(int id)
        {
            throw new NotImplementedException();
        }

        System.Threading.Tasks.Task<List<CartuchoDTO>> ICartuchoService.GetCartuchos(int page, int size)
        {
            throw new NotImplementedException();
        }
    }
}
