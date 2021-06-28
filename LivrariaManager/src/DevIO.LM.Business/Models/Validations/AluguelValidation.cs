using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.LM.Business.Models.Validations
{
    public class AluguelValidation : AbstractValidator<Aluguel>
    {
        public AluguelValidation()
        {
            
            RuleFor(f => f.UsuarioId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(f => f.LivroId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            
            RuleFor(f => f.DataAluguel)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(f => f.DataDevolucao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

        }
    }
}
