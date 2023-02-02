using AutoMapper;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Enumerables;
using QueroComer.Entidades.Interfaces;

namespace QueroComer.Services
{
    public class RestauranteService : IRestauranteService
    {
        private readonly IRestauranteRepository _repository;
        private readonly IEnderecoRepository _enderecoRepository;

        /// <summary>
        ///     Construtor de RestauranteService
        /// </summary>
        public RestauranteService(IRestauranteRepository repository, IEnderecoRepository enderecoRepository)
        {
            _repository = repository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task<Restaurante> CadastrarRestauranteAsync(Restaurante restaurante)
        {
            try
            {
                await _repository.CadastrarRestauranteAsync(restaurante);

                return restaurante;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Restaurante> RecuperarRestaurantePorIdAsync(Guid Id)
        {
            try
            {
                return await _repository.RecuperarRestaurantePorIdAsync(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task<List<Restaurante>> IRestauranteService.RecuperarRestaurantesPorCategoriaAsync(ECategoriaRestaurante categoria)
        {
            try
            {
                return await _repository.RecuperarRestaurantesPorCategoriaAsync(categoria);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
