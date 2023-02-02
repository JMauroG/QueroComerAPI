using QueroComer.Entidades.Entidades;

namespace QueroComer.Entidades.Interfaces
{
    public interface IPedidoProdutoService
    {
        Task<PedidoProduto> CadastrarPedidoProdutoAsync(PedidoProduto pedidoProduto);
        Task<PedidoProduto> AtualizarQuantidadePedidoProdutoAsync(PedidoProduto pedidoProduto);
        Task<PedidoProduto> RecuperarPedidoProdutoPorIdAsync(Guid pedidoProdutoId);
        Task<List<PedidoProduto>> RecuperarPedidoProdutosPorPedidoAsync(Guid pedidoId);
        Task RemoverPedidoProdutoAsync(PedidoProduto pedidoProduto);
    }
}
