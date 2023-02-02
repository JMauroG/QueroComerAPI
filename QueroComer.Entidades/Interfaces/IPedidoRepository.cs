using QueroComer.Entidades.Entidades;

namespace QueroComer.Entidades.Interfaces
{
    public interface IPedidoRepository
    {
        Task CadastrarPedidoAsync(Pedido pedido);
        Task<Pedido> RecuperarPedidoPorIdAsync(Guid Id);
        Task<List<Pedido>> RecuperarPedidosPorUserAsync(string UserId);
        Task<Pedido> AtualizarStatusPedidoAsync(Pedido pedido);
        IEnumerable<Pedido> GetEnumerable();
    }
}
