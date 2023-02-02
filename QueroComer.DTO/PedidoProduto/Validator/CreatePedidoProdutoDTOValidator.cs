using FluentValidation;

namespace QueroComer.DTO.PedidoProduto.Validator
{
    public class CreatePedidoProdutoDTOValidator : AbstractValidator<CreatePedidoProdutoDTO>
    {
        public CreatePedidoProdutoDTOValidator()
        {
            RuleFor(x => x.ProdutoId)
                .NotEmpty()
                .WithMessage("ProdutoId não pode ser vazio");
            RuleFor(x => x.PedidoId)
                .NotEmpty()
                .WithMessage("PedidoId não pode ser vazio");
            RuleFor(x => x.Quantidade)
                .GreaterThan(0)
                .WithMessage("A quantidade deve ser maior que 0");
            RuleFor(x => x.Preco)
                .NotEmpty()
                .WithMessage("Preco não pode ser vazio");
        }
    }
}
