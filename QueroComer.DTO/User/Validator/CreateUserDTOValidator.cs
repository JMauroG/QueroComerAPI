using FluentValidation;
using QueroComer.DTO.User;

namespace QueroComer.DTO.User.Validator
{
    public class CreateUserDTOValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserDTOValidator()
        {
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Email é um campo obrigatório")
                .EmailAddress()
                .WithMessage("O email passado esta com o formato incorreto");

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Password é um campo obrigatório")
                .MinimumLength(8)
                .WithMessage("Password deve ter pelo menos 8 caracteres");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome é um campo obrigatório");

            RuleFor(x => x.Sobrenome)
                .NotEmpty()
                .WithMessage("Sobrenome é um campo obrigatório");

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .WithMessage("Telefone é um campo obrigatório");
        }
    }
}
