using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Enumerables;

namespace QueroComer.Entidades.Interfaces
{
    public interface IRestauranteRepository
    {
        Task CadastrarRestauranteAsync(Restaurante restaurante);
        Task<Restaurante> RecuperarRestaurantePorIdAsync(Guid IdRestaurante);
        Task<List<Restaurante>> RecuperarRestaurantesPorCategoriaAsync(ECategoriaRestaurante categoria);
        IEnumerable<Restaurante> GetEnumerable();
    }
}
