using FluentValidation;

namespace MercadoFrutas.Core.Application.Features.Frutas.Commands.CreateFruta
{
    public class CreateFrutaCommandValidator : AbstractValidator<CreateFrutaCommand>
    {
        public CreateFrutaCommandValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 64 characters.");

            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 256 characters.");

            RuleFor(p => p.Quantidade)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Valor)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}