using Ecommerce.Produto.Application.DTOs;
using FluentValidation;

namespace Ecommerce.Produto.Application.Validators
{
    public class ProdutoDTOValidator : AbstractValidator<ProdutoDTO>
    {
        public ProdutoDTOValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O nome do produto � obrigat�rio.")
                .MaximumLength(100).WithMessage("O nome do produto deve ter no m�ximo 100 caracteres.");

            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("A descri��o do produto � obrigat�ria.")
                .MaximumLength(250).WithMessage("A descri��o do produto deve ter no m�ximo 250 caracteres.");

            RuleFor(p => p.Quantidade)
                .GreaterThanOrEqualTo(0).WithMessage("A quantidade em estoque n�o pode ser negativa.");

            RuleFor(p => p.CategoriaId)
                .GreaterThan(0).WithMessage("O Id da categoria � obrigat�rio e deve ser maior que zero.");
        }
    }
}