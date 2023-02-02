using FluentValidation;

namespace QueroComer.DTO.Restaurante.Validator
{
    public class CreateRestauranteDTOValidator : AbstractValidator<CreateRestauranteDTO>
    {
        public CreateRestauranteDTOValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome é um campo obrigatório");

            RuleFor(x => x.Categoria)
                .IsInEnum()
                .WithMessage("Categoria informada nao existe");

            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("Rua é um campo obrigatório");

            RuleFor(x => x.EnderecoId)
                .NotEmpty()
                .WithMessage("Endereco é um campo obrigatório")
                .NotNull()
                .WithMessage("Endereco é um campo obrigatório");

            RuleFor(x => x.CNPJ)
                .NotEmpty()
                .WithMessage("CNPJ é um campo obrigatório")
                //.Custom((x, context) =>
                //{
                //    if (!int.TryParse(x, out int value) || value < 0)
                //    {
                //        context.AddFailure($"CNPJ passado não é um número");
                //    }
                //})
                .MinimumLength(14)
                .WithMessage("Faltam digitos no CNPJ")
                .MaximumLength(14)
                .WithMessage("Ha digitos a mais no campo de CNPJ ");

        }
    }
}
