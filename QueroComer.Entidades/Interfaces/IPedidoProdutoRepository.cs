using QueroComer.Entidades.Entidades;

namespace QueroComer.Entidades.Interfaces
{
    public interface IPedidoProdutoRepository
    {
        Task CadastrarPedidoProdutoAsync(PedidoProduto pedidoProduto);
        Task<PedidoProduto> RecuperarPedidoProdutoPorIdAsync(Guid pedidoProdutoId);
        Task<List<PedidoProduto>> RecuperarPedidoProdutosPorPedidoAsync(Guid pedidoId);
        Task<PedidoProduto> AtualizarQuantidadePedidoProdutoAsync(PedidoProduto pedidoProduto);
        Task RemoverPedidoProdutoAsync(PedidoProduto pedidoProduto);
        IEnumerable<PedidoProduto> GetEnumerable();
    }
}
