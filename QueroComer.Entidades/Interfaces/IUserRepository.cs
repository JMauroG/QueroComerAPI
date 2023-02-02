using Microsoft.AspNetCore.Identity;

namespace QueroComer.Entidades.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityUser> RetornaUsuarioPorEmailAsync(string email);
        Task<IdentityUser> RetornaUsuarioPorIdAsync(string id);
        IEnumerable<IdentityUser> GetEnumerable();
    }
}
