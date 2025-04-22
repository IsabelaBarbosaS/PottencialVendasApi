using FluentValidation;
using Pottencial.VendasApi.DTOs;

namespace Pottencial.VendasApi.Validators
{
    public class VendaRequestDTOValidator : AbstractValidator<VendaRequestDTO>
    {
        public VendaRequestDTOValidator()
        {
            RuleFor(x => x.Vendedor)
                .NotNull().WithMessage("O vendedor é obrigatório.")
                .SetValidator(new VendedorDTOValidator());

            RuleFor(x => x.Itens)
                .NotNull().WithMessage("A lista de itens não pode ser nula.")
                .NotEmpty().WithMessage("A venda deve conter pelo menos um item.");

            RuleForEach(x => x.Itens)
                .SetValidator(new ItemDTOValidator());
        }
    }
}
