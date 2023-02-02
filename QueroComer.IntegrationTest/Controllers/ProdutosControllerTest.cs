using System.Net;
using System.Net.Http.Headers;

namespace QueroComer.IntegrationTest.Controllers
{
    public class ProdutosControllerTest : BaseTest, IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public ProdutosControllerTest(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        #region RecuperarProdutoPorIdAsync

        [Theory]
        [InlineData("aa61dc7e-ac3a-4a73-9591-c69a9e735167")]
        public async Task Get_RecuperarProdutoPorIdAsync_Success(Guid IdRestaurante)
        {
            //Arrange
            var client = _factory.CreateClient();
            var url = $"api/Produtos/{IdRestaurante}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType!.ToString());
        }

        [Theory]
        [InlineData("aa61dc7e-ac3a-4a73-9591-c69a9e725167")]
        public async Task Get_RecuperarProdutoPorIdAsync_Failure_NotFound(Guid IdProduto)
        {
            //Arrange
            var client = _factory.CreateClient();
            var url = $"api/Produtos/{IdProduto}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Get_RecuperarProdutoPorIdAsync_Failure_IdInvalido()
        {
            //Arrange
            var IdProduto = Guid.Empty;
            var client = _factory.CreateClient();
            var url = $"api/Produtos/{IdProduto}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        #endregion

        #region RecuperarProdutosPorRestauranteAsync

        [Theory]
        [InlineData("aa61dc7e-ac3a-4a73-9591-c69a9e735167")]
        public async Task Get_RecuperarProdutosPorRestauranteAsync_Success(Guid IdRestaurante)
        {
            //Arrange
            var client = _factory.CreateClient();
            var url = $"api/Produtos/Restaurante/{IdRestaurante}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType!.ToString());
        }

        [Theory]
        [InlineData("aa61dc7e-ac3a-4a73-9591-c69a9e735167")]
        public async Task Get_RecuperarProdutosPorRestauranteAsync_Failure_NotFound(Guid IdRestaurante)
        {
            //Arrange
            var client = _factory.CreateClient();
            var url = $"api/Produtos/Restaurante/{IdRestaurante}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Get_RecuperarProdutosPorRestauranteAsync_Failure_IdInvalido()
        {
            //Arrange
            var IdRestaurante = Guid.Empty;
            var client = _factory.CreateClient();
            var url = $"api/Produtos/Restaurante/{IdRestaurante}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        #endregion
    }
}
