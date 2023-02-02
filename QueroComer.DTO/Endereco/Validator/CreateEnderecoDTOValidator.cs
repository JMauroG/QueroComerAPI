using FluentValidation;

namespace QueroComer.DTO.Endereco.Validator
{
    public class CreateEnderecoDTOValidator : AbstractValidator<CreateEnderecoDTO>
    {
        public CreateEnderecoDTOValidator()
        {
            RuleFor(x => x.Rua)
                .NotEmpty()
                .WithMessage("Rua é um campo obrigatório");

            RuleFor(x => x.Numero)
                .NotEmpty()
                .WithMessage("Número é um campo obrigatório");

            RuleFor(x => x.Complemento)
                .NotEmpty()
                .WithMessage("Complemento é um campo obrigatório");

            RuleFor(x => x.Bairro)
                .NotEmpty()
                .WithMessage("Bairro é um campo obrigatório");

            RuleFor(x => x.CEP)
                .NotEmpty()
                .WithMessage("CEP é um campo obrigatório");

            RuleFor(x => x.UF)
                .NotEmpty()
                .WithMessage("UF é um campo obrigatório");

            RuleFor(x => x.Cidade)
                .NotEmpty()
                .WithMessage("Cidade é um campo obrigatório");

            RuleFor(x => x.Pais)
                .NotEmpty()
                .WithMessage("Pais é um campo obrigatório");
        }
    }
}
