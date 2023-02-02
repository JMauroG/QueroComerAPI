using QueroComer.Entidades.Entidades;

namespace QueroComer.Entidades.Interfaces
{
    public interface IProdutoService
    {
        Task<Produto> CadastrarProdutoAsync(Produto produto);
        Task<Produto> RetornarProdutoPorIdAsync(Guid IdProduto);
        Task<List<Produto>> RetornarProdutosPorRestauranteAsync(Guid IdRestaurante);
    }
}
