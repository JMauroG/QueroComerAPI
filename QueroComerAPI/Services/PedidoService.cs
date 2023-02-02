using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Interfaces;

namespace QueroComer.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _repository;
        private readonly IEnderecoRepository _enderecoRepository;

        public PedidoService(IPedidoRepository repository,
                             IEnderecoRepository enderecoRepository)
        {
            _repository = repository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task<Pedido> CadastrarPedidoAsync(Pedido pedido)
        {
            try
            {
                await _repository.CadastrarPedidoAsync(pedido);

                return pedido;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Pedido> RecuperarPedidoPorIdAsync(Guid Id)
        {
            try
            {
                return await _repository.RecuperarPedidoPorIdAsync(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Pedido>> RecuperarPedidosPorUserAsync(string IdUsuario)
        {
            try
            {
                return await _repository.RecuperarPedidosPorUserAsync(IdUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Pedido> AtualizarStatusPedidoAsync(Pedido pedido)
        {
            try
            {
                await _repository.AtualizarStatusPedidoAsync(pedido);
                return pedido;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
