using Ecommerce.Produto.Application.DTOs;
using FluentValidation;

namespace Ecommerce.Produto.Application.Validators
{
    public class ProdutoDTOValidator : AbstractValidator<ProdutoDTO>
    {
        public ProdutoDTOValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O nome do produto é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do produto deve ter no máximo 100 caracteres.");

            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("A descrição do produto é obrigatória.")
                .MaximumLength(250).WithMessage("A descrição do produto deve ter no máximo 250 caracteres.");

            RuleFor(p => p.Quantidade)
                .GreaterThanOrEqualTo(0).WithMessage("A quantidade em estoque não pode ser negativa.");

            RuleFor(p => p.CategoriaId)
                .GreaterThan(0).WithMessage("O Id da categoria é obrigatório e deve ser maior que zero.");
        }
    }
}