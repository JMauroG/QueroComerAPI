using FluentValidation;

namespace QueroComer.Entidades.Entidades.Validator
{
    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Email eh um campo obrigatorio")
                .EmailAddress()
                .WithMessage("O email passado esta com o formato incorreto");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password eh um campo obrigatorio");
        }
    }
}
