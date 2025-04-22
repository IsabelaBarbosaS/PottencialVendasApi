using FluentValidation;
using Pottencial.VendasApi.DTOs;

namespace Pottencial.VendasApi.Validators
{
    public class ItemDTOValidator : AbstractValidator<ItemDTO>
    {
        public ItemDTOValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome do item é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do item deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Preco)
                .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");

            RuleFor(x => x.Quantidade)
                .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.");
        }
    }
}
