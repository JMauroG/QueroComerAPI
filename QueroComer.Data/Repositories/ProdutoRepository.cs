using Microsoft.EntityFrameworkCore;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Interfaces;

namespace QueroComer.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CadastrarProdutoAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto> RecuperarProdutoPorIdAsync(Guid IdProduto)
        {
            return await _context.Produtos.FirstOrDefaultAsync(x => x.Id.Equals(IdProduto));
        }

        public async Task<List<Produto>> RecuperarProdutosPorRestauranteAsync(Guid IdRestaurante)
        {
            return await _context.Produtos.Include(x => x.Restaurante)
                            .Where(x => x.Restaurante.Id.Equals(IdRestaurante))
                            .ToListAsync();
        }

        public IEnumerable<Produto> GetEnumerable()
        {
            return _context.Produtos;
        }
    }
}
