using Microsoft.AspNetCore.Identity;
using QueroComer.Entidades.Entidades;

namespace QueroComer.Entidades.Interfaces
{
    public interface IEnderecoRepository
    {
        Task CadastrarEnderecoAsync(Endereco endereco);
        Task<Endereco> RecuperarEnderecoPorIdAsync(Guid IdEndereco);
        Task<List<Endereco>> RecuperarEnderecosPorUsuarioAsync(IdentityUser user);
        IEnumerable<Endereco> GetEnumerable();
    }
}
