using FluentValidation;
using QueroComer.DTO.Pedido;

namespace QueroComer.DTO.PedidoProduto.Validator
{
    public class UpdatePedidoProdutoDTOValidator : AbstractValidator<UpdatePedidoProdutoDTO>
    {
        public UpdatePedidoProdutoDTOValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id não pode ser vazio");
        }
    }
}
