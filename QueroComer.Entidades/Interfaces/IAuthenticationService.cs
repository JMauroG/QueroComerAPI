using QueroComer.Entidades.Entidades;

namespace QueroComer.Entidades.Interfaces
{
    public interface IAuthenticationService
    {
        Task<RespostaLogin> LoginAsync(Login login);
    }
}
