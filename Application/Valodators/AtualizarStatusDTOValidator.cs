using FluentValidation;
using Pottencial.VendasApi.DTOs;

namespace Pottencial.VendasApi.Validators
{
    public class AtualizarStatusDTOValidator : AbstractValidator<AtualizarStatusDTO>
    {
        public AtualizarStatusDTOValidator()
        {
            RuleFor(x => x.NovoStatus)
                .IsInEnum()
                .WithMessage("O status fornecido é inválido.");
        }
    }
}
