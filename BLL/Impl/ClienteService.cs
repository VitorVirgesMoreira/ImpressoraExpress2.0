using BLL.Interfaces;
using BLL.Validator;
using Common;
using DAO;
using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository repository;
        public ClienteService(IClienteRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<ClienteDTO>> GetData()
        {
            return await repository.GetData();
        }

        public async Task Insert(ClienteDTO cliente)
        {

            List<Error> errors = new List<Error>();
            if (string.IsNullOrWhiteSpace(cliente.Nome))
            {
                base.AddError("Nome", "Nome deve ser informado");
            }
            else if (cliente.Nome.Length < 5 || cliente.Nome.Length > 50)
            {
                base.AddError("Nome", "O nome deve conter entre 5 e 50 caracteres");
            }

            string cpf = cliente.CPF;
            if (string.IsNullOrWhiteSpace(cpf))
            {
                base.AddError("CPF", "CPF deve ser informado");
            }
            else if (cpf.Length != 14)
            {
                base.AddError("CPF", "CPF deve conter 14 caracteres.");
            }
            else if (!cpf.IsCpf())
            {
                base.AddError("CPF", "CPF inválido");
            }

            if (string.IsNullOrWhiteSpace(cliente.Email))
            {
                base.AddError("Email", "Email deve ser informado");
            }
            else if (cliente.Email.Length < 5 || cliente.Email.Length > 60)
            {
                base.AddError("Email", "Email deve conter entre 5 e 60 caracteres.");
            }

            TimeSpan dezesseisAnosDeVida = new TimeSpan(5844, 0, 0, 0);
            TimeSpan centoEQuinzeAnosDeVida = new TimeSpan(42004, 0, 0, 0);
            if (DateTime.Now.Subtract(dezesseisAnosDeVida) <= cliente.DataNascimento)
            {
                base.AddError("DataNascimento", "Você deve possuir acima de 16 anos para se cadastrar!");

            }
            else if (DateTime.Now.Subtract(centoEQuinzeAnosDeVida) >= cliente.DataNascimento)
            {
                base.AddError("DataNascimento", "Você deve possuir menos de 115 anos meo, milagres acontecem.");
            }

            base.CheckErrors();
            await repository.Create(cliente);
        }

        public Task Update(ClienteDTO cliente)
        {
            throw new NotImplementedException();
        }
    }
}
