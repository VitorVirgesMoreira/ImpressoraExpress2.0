using BLL.Interfaces;
using Common;
using DAO;
using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace BLL.Impl
{
    public class ImpressoraService : BaseService, IImpressoraService
    {
        private readonly IImpressoraRepository repository;
        public ImpressoraService(IImpressoraRepository repository)
        {
            this.repository = repository;
        }

        public async Task Insert(ImpressoraDTO impressora)
        {
            List<Error> errors = new List<Error>();
            if (string.IsNullOrWhiteSpace(impressora.Modelo))
            {
                base.AddError("Modelo", "Modelo deve ser informado");
            }
            else if (impressora.Modelo.Length < 5 || impressora.Modelo.Length > 150)
            {
                base.AddError("Modelo", "Modelo deve conter entre 5 a 50 caracteres!");
            }
            
            string valorConvetido = Convert.ToString(impressora.Valor);
            if (string.IsNullOrWhiteSpace(valorConvetido))
            {
                base.AddError("Valor","Valor deve ser informado");

            }
            else if (impressora.Valor < 150)
            {
                base.AddError("Valor", "Valor da impressora deve ser maior que R$150,00");
            }

            base.CheckErrors();
            await repository.Create(impressora);
        }

        public Task Update(ImpressoraDTO impressora)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ImpressoraDTO>> GetData()
        {
            return await repository.GetData();
        }
    }
}          
