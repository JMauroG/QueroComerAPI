using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Interfaces;

namespace QueroComer.Services
{
    public class PedidoProdutoService : IPedidoProdutoService
    {
        private readonly IPedidoProdutoRepository _repository;

        public PedidoProdutoService(IPedidoProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<PedidoProduto> CadastrarPedidoProdutoAsync(PedidoProduto pedidoProduto)
        {
            try
            {
                await _repository.CadastrarPedidoProdutoAsync(pedidoProduto);
                return pedidoProduto;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        
        public async Task<PedidoProduto> AtualizarQuantidadePedidoProdutoAsync(PedidoProduto pedidoProduto)
        {
            try
            {
                await _repository.AtualizarQuantidadePedidoProdutoAsync(pedidoProduto);
                return pedidoProduto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PedidoProduto> RecuperarPedidoProdutoPorIdAsync(Guid pedidoProdutoId)
        {
            try
            {
                return await _repository.RecuperarPedidoProdutoPorIdAsync(pedidoProdutoId);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<List<PedidoProduto>> RecuperarPedidoProdutosPorPedidoAsync(Guid pedidoId)
        {
            try
            {
                return await _repository.RecuperarPedidoProdutosPorPedidoAsync(pedidoId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task RemoverPedidoProdutoAsync(PedidoProduto pedidoProduto)
        {
            try
            {
                await _repository.RemoverPedidoProdutoAsync(pedidoProduto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
