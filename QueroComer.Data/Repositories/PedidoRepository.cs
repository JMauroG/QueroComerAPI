using Microsoft.EntityFrameworkCore;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Interfaces;

namespace QueroComer.Data.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CadastrarPedidoAsync(Pedido pedido)
        {
            try
            {
                await _context.Pedidos.AddAsync(pedido);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Pedido> RecuperarPedidoPorIdAsync(Guid Id)
        {
            return await _context.Pedidos.FirstOrDefaultAsync(x => x.Id.Equals(Id));

        }

        public async Task<List<Pedido>> RecuperarPedidosPorUserAsync(string IdUser)
        {
            return await _context.Pedidos.Where(x => x.UserId.Equals(IdUser)).ToListAsync();
        }

        public async Task<Pedido> AtualizarStatusPedidoAsync(Pedido pedido)
        {
            try
            {
                _context.Pedidos.Update(pedido);
                await _context.SaveChangesAsync();

                return pedido;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Pedido> GetEnumerable()
        {
            return _context.Pedidos;
        }
    }
}
