using QueroComer.Entidades.Entidades;

namespace QueroComer.Entidades.Interfaces
{
    public interface IEnderecoService
    {
        Task<Endereco> CadastrarEnderecoAsync(string IdUsuario, Endereco endereco);
        Task<Endereco> RecuperarEnderecoPorIdAsync(Guid IdEndereco);
        Task<List<Endereco>> RecuperarEnderecosPorUsuarioAsync(string IdUsuario);
        Task<bool> VerificarSeEnderecoExiste(Guid IdEndereco);
    }
}
