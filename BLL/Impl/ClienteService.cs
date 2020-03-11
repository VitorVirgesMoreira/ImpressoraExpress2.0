using BLL.Interfaces;
using BLL.Validator;
using Common;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class ClienteService : BaseService, IClienteService
    {
        public async Task<List<ClienteDTO>> GetData()
        {
            try
            {
                using (ExpressDbContext context = new ExpressDbContext())
                {
                    return await context.Clientes.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + "-" + ex.StackTrace);
                throw new Exception("Erro no Banco de dados, contate o administrador");
            }
            
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
            else if (cpf.Length > 11)
            {
                base.AddError("CPF", "CPF deve conter 11 caracteres.");
            }
            else if(!cpf.IsCpf())
            {
                base.AddError("CPF", "CPF inválido");
            }

            if (string.IsNullOrWhiteSpace(cliente.Email))
            {
                base.AddError("Email", "Email deve ser informado");
            }
            else if(cliente.Email.Length < 5 || cliente.Email.Length > 60)
            {
                base.AddError("Email", "Email deve conter entre 5 e 60 caracteres.");
            }
            TimeSpan dezesseisAnosDeVida = new TimeSpan(5844, 0, 0, 0);
            TimeSpan centoEQuinzeAnosDeVida = new TimeSpan(42004, 0, 0, 0);


            if (DateTime.Now.Subtract(dezesseisAnosDeVida).Date > cliente.DataNascimento)
            {
                base.AddError("DataNascimento", "Você deve possuir acima de 16 anos para se cadastrar!");

            }
            else if (DateTime.Now.Subtract(centoEQuinzeAnosDeVida).Date > cliente.DataNascimento)
            {
                base.AddError("DataNascimento", "Você deve possuir menos de 115 anos meo, milagres acontecem.");
            }
            base.CheckErrors();
            try
            {
                using (ExpressDbContext context = new ExpressDbContext())
                {
                    context.Clientes.Add(cliente);
                    await context.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o admnistrador.");
            }
            
        }
    }
}
