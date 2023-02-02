using AutoMapper;
using NSubstitute;
using QueroComer.DTO.Restaurante;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Enumerables;
using QueroComer.Entidades.Interfaces;
using QueroComer.Mock.DTO.Restaurante;
using QueroComer.Mock.Entidades;
using QueroComer.Profiles;
using QueroComer.Services;

namespace QueroComer.UnitTest.Services
{
    public class RestauranteServiceTest
    {
        private readonly IRestauranteRepository _repositoryMock;
        private readonly IEnderecoRepository _enderecoRepositoryMock;
        private readonly IRestauranteService _serviceMock;
        private readonly IMapper _mapper;

        public RestauranteServiceTest()
        {
            var mapperProfile = new MapperProfile();
            var configuration = new MapperConfiguration(x => x.AddProfile(mapperProfile));
            _mapper = new Mapper(configuration);

            _repositoryMock = Substitute.For<IRestauranteRepository>();
            _enderecoRepositoryMock = Substitute.For<IEnderecoRepository>();
            _serviceMock = new RestauranteService(_repositoryMock, _enderecoRepositoryMock);
        }

        [Fact]
        public async Task RestauranteService_CadastroRestauranteAsync_Success()
        {
            //Arrange
            CreateRestauranteDTO createrRestauranteDTOMock = CreateRestauranteDTOMock.GetCreateRestauranteDTOMock();
            Restaurante restauranteMock = _mapper.Map<Restaurante>(createrRestauranteDTOMock);

            //Act
            var actualRestaurante = await _serviceMock.CadastrarRestauranteAsync(restauranteMock);

            //Assert
            Assert.Equal(restauranteMock.Nome, actualRestaurante.Nome);
            Assert.Equal(restauranteMock.Categoria, actualRestaurante.Categoria);
            Assert.Equal(restauranteMock.Descricao, actualRestaurante.Descricao);
            Assert.Equal(restauranteMock.EnderecoId, actualRestaurante.EnderecoId);
        }

        [Fact]
        public async Task RestauranteService_RecuperarRestaurantePorIdAsync_Success()
        {
            //Arrange
            Restaurante restauranteMock = RestauranteMock.GetRestauranteMock();
            _repositoryMock.RecuperarRestaurantePorIdAsync(restauranteMock.Id).Returns(restauranteMock);

            //Act
            var actualRestaurante = await _serviceMock.RecuperarRestaurantePorIdAsync(restauranteMock.Id);

            //Assert
            Assert.Equal(restauranteMock, actualRestaurante);

        }

        [Fact]
        public async Task RestauranteRepository_RecuperarRestaurantesPorCategoriaAsync_Success()
        {
            //Arrange
            var categoria = ECategoriaRestaurante.Frances;
            List<Restaurante> listRestauranteMock = RestauranteMock.GetRestauranteListMock(categoria);
            _repositoryMock.RecuperarRestaurantesPorCategoriaAsync(categoria).Returns(listRestauranteMock);

            //Act
            var actualListRestaurante = await _serviceMock.RecuperarRestaurantesPorCategoriaAsync(categoria);

            //Assert
            Assert.Equal(listRestauranteMock, actualListRestaurante);
        }
    }
}
