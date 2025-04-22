using FluentValidation;
using Pottencial.VendasApi.DTOs;

namespace Pottencial.VendasApi.Validators
{
    public class VendedorDTOValidator : AbstractValidator<VendedorDTO>
    {
        public VendedorDTOValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome do vendedor é obrigatório.")
                .MaximumLength(100).WithMessage("O nome pode ter no máximo 100 caracteres.");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Length(11).WithMessage("O CPF deve conter exatamente 11 dígitos.")
                .Matches("^[0-9]*$").WithMessage("O CPF deve conter apenas números.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("O e-mail fornecido não é válido.");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\d{10,11}$").WithMessage("O telefone deve ter 10 ou 11 dígitos numéricos.");
        }
    }
}
