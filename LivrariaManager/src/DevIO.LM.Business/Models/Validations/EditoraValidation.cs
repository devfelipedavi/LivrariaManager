using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.LM.Business.Models.Validations
{
    public class EditoraValidation : AbstractValidator<Editora>
    {
        public EditoraValidation()
        {
            RuleFor(f => f.Nome)
                  .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                  .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Estado)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
              .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("A campo {PropertyName} precisa ser fornecida")
                .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");            

        }
    }
}
