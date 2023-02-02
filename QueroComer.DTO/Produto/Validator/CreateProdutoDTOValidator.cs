using FluentValidation;

namespace QueroComer.DTO.Produto.Validator
{
    public class CreateProdutoDTOValidator : AbstractValidator<CreateProdutoDTO>
    {
        public CreateProdutoDTOValidator()
        {
            RuleFor(x => x.RestauranteId)
                .NotEmpty()
                .WithMessage("Restaurante é um campo obrigatório");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome é um campo obrigatório");

            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("Descricao é um campo obrigatório");

            RuleFor(x => x.Categoria)
                .IsInEnum()
                .WithMessage("Categoria informada nao existe");

            RuleFor(x => x.Preco)
                .NotEmpty()
                .WithMessage("Preco é um campo obrigatório");
        }
    }
}
