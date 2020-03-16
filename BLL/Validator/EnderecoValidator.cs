using DTO.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

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
            else if (string.IsNullOrWhiteSpace(endereco.Rua))
                {
                errors.Add(new Error() { FieldName = "Rua", Message = "Rua deve ser informada" });

            }
            else if (string.IsNullOrWhiteSpace(endereco.Cidade))
            {
                errors.Add(new Error() { FieldName = "Cidade", Message = "Cidade deve ser informada" });
            }
            else if (string.IsNullOrWhiteSpace(endereco.UF))
            {
                errors.Add(new Error() { FieldName = "UF", Message = "UF deve ser informado" });

            }
            else if (string.IsNullOrWhiteSpace(endereco.Numero))
            {
                errors.Add(new Error() { FieldName = "Numero", Message = "Numero deve ser informado" });

            }
            else if (string.IsNullOrWhiteSpace(endereco.Complemento))
            {
                errors.Add(new Error() { FieldName = "Complemento", Message = "Complemento deve ser informado" });
            }
                
            //FAZER DE TODOS OS CAMPOS
            return errors;
        }
    }
}
