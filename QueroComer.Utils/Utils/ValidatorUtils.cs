using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace QueroComer.Utils
{
    public class ValidatorUtils
    {
        public static List<string> ListarErros(List<ValidationFailure> erros)
        {
            var errorList = new List<string>();
            foreach(var erro in erros)
                errorList.Add(erro.ErrorMessage);

            return errorList;
        }

        public static List<string> ListarErros(List<IdentityError> erros)
        {
            var errorList = new List<string>();
            foreach (var erro in erros)
                errorList.Add(erro.Description);

            return errorList;
        }
    }
}
