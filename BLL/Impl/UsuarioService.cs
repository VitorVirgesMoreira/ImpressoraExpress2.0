﻿using BLL.Interfaces;
using BLL.Validator;
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
    public class Task<UsuarioService> : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository repository;

        public Task(IUsuarioRepository repository)
        {
            this.repository = repository;
        }
        public async Task Create(UsuarioDTO usuario)
        {
            List<Error> errors = new List<Error>();
            if (string.IsNullOrWhiteSpace(usuario.Nome))
            {
                base.AddError("Nome", "Nome deve ser informado");
            }
            else if (usuario.Nome.Length < 5 || usuario.Nome.Length > 50)
            {
                base.AddError("Nome", "O nome deve conter entre 5 e 50 caracteres");
            }

            string cpf = usuario.CPF;
            if (string.IsNullOrWhiteSpace(cpf))
            {
                base.AddError("CPF", "CPF deve ser informado");
            }
            else if (cpf.Length > 11)
            {
                base.AddError("CPF", "CPF deve conter 11 caracteres.");
            }
            else if (!cpf.IsCpf())
            {
                base.AddError("CPF", "CPF inválido");
            }

            if (string.IsNullOrWhiteSpace(usuario.Email))
            {
                base.AddError("Email", "Email deve ser informado");
            }
            else if (usuario.Email.Length < 5 || usuario.Email.Length > 60)
            {
                base.AddError("Email", "Email deve conter entre 5 e 60 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(usuario.Senha))
            {
                base.AddError("Senha", "Senha deve ser informada");
            }
            else if (usuario.Email.Length < 5 || usuario.Email.Length > 70)
            {
                base.AddError("Senha", "Senha deve conter entre 5 e 70 caracteres.");
            }

            base.CheckErrors();
            //try
            //{
            //    using (ExpressDbContext context = new ExpressDbContext())
            //    {
            //        context.Usuarios.Add(usuario);
            //        await context.SaveChangesAsync();

            //    }
            //}
            //catch (Exception ex)
            //{
            //    File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
            //    throw new Exception("Erro no banco de dados, contate o admnistrador.");
            //}
            //await repository.Create(usuario);

            await repository.Create(usuario);

        }

        

        System.Threading.Tasks.Task<UsuarioDTO> IUsuarioService.Authenticate(string email, string password)
        {
            return repository.Authenticate(email, password);

        }
    }
}
