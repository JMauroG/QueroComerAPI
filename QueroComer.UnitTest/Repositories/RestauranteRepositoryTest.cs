using QueroComer.Data.Repositories;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Enumerables;
using QueroComer.Mock;
using QueroComer.Mock.Entidades;

namespace QueroComer.UnitTest.Repositories
{
    public class RestauranteRepositoryTest
    {
        [Fact]
        public async Task RestauranteRepository_CadastrarRestauranteAsync_Success()
        {
            //Arrange
            Restaurante restauranteMock = RestauranteMock.GetRestauranteMock();
            var contextMock = new InMemoryDbContextFactory().GetDbContext("CadastrarRestauranteAsyncTest");
            var restauranteRepositoryMock = new RestauranteRepository(contextMock);

            //Act
            await restauranteRepositoryMock.CadastrarRestauranteAsync(restauranteMock);
            var restaurantes = restauranteRepositoryMock.GetEnumerable();

            //Assert
            Assert.Contains(restauranteMock, restaurantes);
        }

        [Fact]
        public async Task RestauranteRepository_RecuperarRestaurantePorIdAsync_Success()
        {
            //Arrange
            Restaurante restauranteMock = RestauranteMock.GetRestauranteMock();
            var contextMock = new InMemoryDbContextFactory().GetDbContext("RecuperarRestaurantePorIdAsyncTest");
            await contextMock.Restaurantes.AddAsync(restauranteMock);
            await contextMock.SaveChangesAsync();
            var restauranteRepositoryMock = new RestauranteRepository(contextMock);

            //Act
            var acturalRestaurante = await restauranteRepositoryMock.RecuperarRestaurantePorIdAsync(restauranteMock.Id);

            //Assert
            Assert.Equal(restauranteMock.Id, acturalRestaurante.Id);
        }

        [Fact]
        public async Task RestauranteRepository_RecuperarRestaurantesPorCategoriaAsync_Success()
        {
            //Arrange
            var categoria = ECategoriaRestaurante.Mexicana;
            List<Restaurante> listRestauranteMock = RestauranteMock.GetRestauranteListMock(categoria);
            var contextMock = new InMemoryDbContextFactory().GetDbContext("RecuperarRestaurantesPorCategoriaAsyncTest");
            await contextMock.Restaurantes.AddRangeAsync(listRestauranteMock);
            await contextMock.SaveChangesAsync();
            var restauranteRepositoryMock = new RestauranteRepository(contextMock);

            //Act
            var actualRestaurantes = await restauranteRepositoryMock.RecuperarRestaurantesPorCategoriaAsync(categoria);

            //Assert
            Assert.Equal(listRestauranteMock, actualRestaurantes);
        }
    }
}
