using FluentValidation;

namespace QueroComer.DTO.Pedido.Validator
{
    public class CreatePedidoDTOValidator : AbstractValidator<CreatePedidoDTO>
    {
        public CreatePedidoDTOValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("É preciso estar logado para efetuar um pedido");
            RuleFor(x => x.EnderecoId)
                .NotEmpty()
                .WithMessage("É preciso selecionar um endereço para entrega");
            RuleFor(x => x.RestauranteId)
                .NotEmpty()
                .WithMessage("É preciso informar o Restaurante");
            RuleFor(x => x.Preco)
                .NotEmpty()
                .WithMessage("Preço inválido");
        }
    }
}
