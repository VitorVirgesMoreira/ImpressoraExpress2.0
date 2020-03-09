using DTO.ComplexTypes;
using Microsoft.Build.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Validator
{
    public class EnderecoValidator
    {
        public List<Error> Validate(Endereco endereco)
        {
            List<Error> errors = new List<Error>();

            if (string.IsNullOrWhiteSpace(endereco.Bairro))
            {
                errors.Add(new Error() { FieldName = "Bairro", Message = "Bairro deve ser informado." });
            }
            else if (string,IsNullOrWhiteSpace(endereco.Rua)
            //FAZER DE TODOS OS CAMPOS
            return errors;
        }
    }
}
