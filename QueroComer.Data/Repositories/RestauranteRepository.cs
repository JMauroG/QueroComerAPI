using Microsoft.EntityFrameworkCore;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Enumerables;
using QueroComer.Entidades.Interfaces;

namespace QueroComer.Data.Repositories
{
    public class RestauranteRepository : IRestauranteRepository
    {
        private readonly AppDbContext _context;

        public RestauranteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CadastrarRestauranteAsync(Restaurante restaurante)
        {
            _context.Restaurantes.Add(restaurante);
            await _context.SaveChangesAsync();
        }

        public async Task<Restaurante> RecuperarRestaurantePorIdAsync(Guid IdRestaurante)
        {
            return await _context.Restaurantes.FirstOrDefaultAsync(x => x.Id.Equals(IdRestaurante));
        }

        public async Task<List<Restaurante>> RecuperarRestaurantesPorCategoriaAsync(ECategoriaRestaurante categoria)
        {
            return await _context.Restaurantes.Where( x => x.Categoria == categoria ).ToListAsync();
        }

        public IEnumerable<Restaurante> GetEnumerable()
        {
            return _context.Restaurantes;
        }
    }
}
