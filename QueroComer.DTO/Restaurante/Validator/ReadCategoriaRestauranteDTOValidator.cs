using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueroComer.DTO.Restaurante.Validator
{
    public class ReadCategoriaRestauranteDTOValidator : AbstractValidator<ReadCategoriaRestauranteDTO>
    {
        public ReadCategoriaRestauranteDTOValidator()
        {
            RuleFor(x => x.Categoria)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Categoria eh obrigatoria")
                .NotEmpty().WithMessage("Categoria eh obrigatoria")
                .IsInEnum().WithMessage("Categoria Invalida");
        }
    }
}
