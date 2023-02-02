using Microsoft.EntityFrameworkCore;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Interfaces;

namespace QueroComer.Data.Repositories
{
    public class PedidoProdutoRepository : IPedidoProdutoRepository
    {
        private readonly AppDbContext _context;

        public PedidoProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CadastrarPedidoProdutoAsync (PedidoProduto pedidoProduto)
        {
            await _context.PedidosProdutos.AddAsync(pedidoProduto);
            await _context.SaveChangesAsync();
        }

        public async Task<PedidoProduto> RecuperarPedidoProdutoPorIdAsync(Guid pedidoProdutoId)
        {
            return await _context.PedidosProdutos.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(pedidoProdutoId));
        }

        public async Task<List<PedidoProduto>> RecuperarPedidoProdutosPorPedidoAsync(Guid pedidoId)
        {
            return await _context.PedidosProdutos.Where(x => x.PedidoId.Equals(pedidoId)).ToListAsync();
        }

        public async Task<PedidoProduto> AtualizarQuantidadePedidoProdutoAsync(PedidoProduto pedidoProduto)
        {
            _context.PedidosProdutos.Update(pedidoProduto);
            await _context.SaveChangesAsync();

            return pedidoProduto;
        }

        public async Task RemoverPedidoProdutoAsync(PedidoProduto pedidoProduto)
        {
            _context.PedidosProdutos.Remove(pedidoProduto);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<PedidoProduto> GetEnumerable()
        {
            return _context.PedidosProdutos;
        }

    }
}
