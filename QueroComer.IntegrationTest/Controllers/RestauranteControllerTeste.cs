using Newtonsoft.Json;
using QueroComer.DTO.Restaurante;
using QueroComer.Entidades.Enumerables;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace QueroComer.IntegrationTest.Controllers
{
    public class RestauranteControllerTeste : BaseTest, IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public RestauranteControllerTeste(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("3d5ed7ce-073e-484c-964f-b280f53b86ee")]
        [InlineData("9c022e4a-dcb6-4cbf-a2a0-9b5f40b9419b")]
        public async Task Get_RecuperarRestaurantePorIdAsync_Success(Guid IdRestaurante)
        {
            //Arrange
            var client = _factory.CreateClient();
            var url = $"api/Restaurantes/{IdRestaurante}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType!.ToString());
        }

        [Theory]
        [InlineData("9c022e4a-dcb6-4cbf-a2a0-9b5f40b9419c")]
        public async Task Get_RecuperarRestaurantePorIdAsync_Failure_NotFound(Guid IdRestaurante)
        {
            //Arrange
            var client = _factory.CreateClient();
            var url = $"api/Restaurantes/{IdRestaurante}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Get_RecuoerarRestaurantePorIdasync_Failure_IdInvalido()
        {
            //Arrange
            var IdRestaurante = Guid.Empty;
            var client = _factory.CreateClient();
            var url = $"api/Restaurantes/{IdRestaurante}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [MemberData(nameof(CategoriaRestaurante))]
        public async Task Get_RecuperarRestaurantePorCategoriaAsync_Success(string categoria)
        {
            //Arrange
            var client = _factory.CreateClient();
            var url = $"api/Restaurantes/Categoria/{categoria}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType!.ToString());
        }

        [Theory]
        [MemberData(nameof(CategoriaRestauranteNaoCadastrado))]
        public async Task Get_RecuperarRestaurantePorCategoriaAsync_Failure_NotFound(int categoria)
        {
            //Arrange
            var client = _factory.CreateClient();
            var url = $"api/Restaurantes/Categoria";
            var readCategoriaRestauranteDTO = new ReadCategoriaRestauranteDTO()
            {
                Categoria = Enum.GetValues<ECategoriaRestaurante>().FirstOrDefault(x => (int)x == categoria)
            };
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Content = new StringContent(JsonConvert.SerializeObject(readCategoriaRestauranteDTO), Encoding.UTF8, "application/json");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Get_RecuperarRestaurantePorCategoriaAsync_Failure_CategoriaInvalida()
        {
            //Arrange
            var categoria = Enum.GetNames<ECategoriaRestaurante>().Count() + 1;
            var client = _factory.CreateClient();
            var url = $"api/Restaurantes/Categoria/{categoria}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        public static IEnumerable<object[]> CategoriaRestaurante()
        {
            yield return new object[] { ECategoriaRestaurante.Italiano };
            yield return new object[] { ECategoriaRestaurante.Brasileira };
            yield return new object[] { ECategoriaRestaurante.Churrascaria };
            yield return new object[] { ECategoriaRestaurante.Arabe };
        }

        public static IEnumerable<object[]> CategoriaRestauranteNaoCadastrado()
        {
            yield return new object[] { ECategoriaRestaurante.Vegetariana };
            yield return new object[] { ECategoriaRestaurante.Japones };
        }

    }
}
