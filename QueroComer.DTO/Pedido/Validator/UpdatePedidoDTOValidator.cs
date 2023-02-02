using FluentValidation;

namespace QueroComer.DTO.Pedido.Validator
{
    public class UpdatePedidoDTOValidator : AbstractValidator<UpdatePedidoDTO>
    {
        public UpdatePedidoDTOValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("É precisso informar o id do pedido");

            RuleFor(x => x.Status)
                .IsInEnum()
                .WithMessage("Status informada não existe");
        }
    }
}
