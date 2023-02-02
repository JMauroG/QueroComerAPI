using Microsoft.AspNetCore.Identity;
using QueroComer.Entidades.Entidades;

namespace QueroComer.Entidades.Interfaces
{
    public interface IUserService
    {
        Task<IdentityUser> RetornaUsuarioPorIdAsync(string Id);
        Task<IdentityUser> RetornaUsuarioPorEmailAsync(string email);
        Task<Resposta> CadastrarUsuarioAsync(IdentityUser novoUser);
        IdentityUser CreateIdentityUser(Usuario usuario);
    }
}
