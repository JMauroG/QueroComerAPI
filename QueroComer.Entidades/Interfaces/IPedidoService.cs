using QueroComer.Entidades.Entidades;

namespace QueroComer.Entidades.Interfaces
{
    public interface IPedidoService
    {
        Task<Pedido> CadastrarPedidoAsync(Pedido pedido);
        Task<Pedido> RecuperarPedidoPorIdAsync(Guid Id);
        Task<List<Pedido>> RecuperarPedidosPorUserAsync(string UserId);
        Task<Pedido> AtualizarStatusPedidoAsync(Pedido pedido);
    }
}
