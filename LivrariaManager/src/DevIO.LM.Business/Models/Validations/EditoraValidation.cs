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
            RuleFor(f => f.CodEditora)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
                
           RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        }
    }
}
