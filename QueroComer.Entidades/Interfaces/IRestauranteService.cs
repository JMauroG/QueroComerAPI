using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Enumerables;

namespace QueroComer.Entidades.Interfaces
{
    public interface IRestauranteService
    {
        Task<Restaurante> CadastrarRestauranteAsync(Restaurante Restaurante);
        Task<Restaurante> RecuperarRestaurantePorIdAsync(Guid Id);
        Task<List<Restaurante>> RecuperarRestaurantesPorCategoriaAsync(ECategoriaRestaurante categoria);
    }
}
