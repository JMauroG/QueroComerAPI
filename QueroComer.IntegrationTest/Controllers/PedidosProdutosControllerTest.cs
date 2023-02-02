using System.Net;
using System.Net.Http.Headers;

namespace QueroComer.IntegrationTest.Controllers
{
    public class PedidosProdutosControllerTest : BaseTest, IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public PedidosProdutosControllerTest(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        #region RecuperarPedidoProdutoPorIdAsync

        [Theory]
        [InlineData("6f367a35-e37e-475c-aeec-f37bb480956e")]
        public async Task Get_RecuperarPedidoProdutoPorIdAsync_Success(Guid IdPedido)
        {
            //Arrange
            var client = _factory.CreateClient();
            var url = $"api/PedidosProdutros/{IdPedido}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType!.ToString());
        }

        [Theory]
        [InlineData("6f367a35-e37e-475c-aeec-f37bb480926e")]
        public async Task Get_RecuperarPedidoProdutoPorIdAsync_Failure_NotFound(Guid IdPedidoProduto)
        {
            //Arrange
            var client = _factory.CreateClient();
            var url = $"api/PedidosProdutros/{IdPedidoProduto}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Get_RecuperarPedidoProdutoPorIdAsync_Failure_IdInvalido()
        {
            //Arrange
            var IdPedidoProduto = Guid.Empty;
            var client = _factory.CreateClient();
            var url = $"api/PedidosProdutros/{IdPedidoProduto}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        #endregion

        #region RecuperarPedidoProdutosPorPedidoAsync

        [Theory]
        [InlineData("aa6caffd-d52f-4db4-9b89-781a98d8ebbc")]
        public async Task Get_RecuperarPedidoProdutosPorPedidoAsync_Success(Guid IdPedido)
        {
            //Arrange
            var client = _factory.CreateClient();
            var url = $"api/PedidosProdutros/{IdPedido}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType!.ToString());
        }

        [Theory]
        [InlineData("ba6caffd-d52f-4db4-9b89-781a98d8ebbc")]
        public async Task Get_RecuperarPedidoProdutosPorPedidoAsync_Failure_NotFound(Guid IdPedido)
        {
            //Arrange
            var client = _factory.CreateClient();
            var url = $"api/PedidosProdutros/{IdPedido}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound,response.StatusCode);
        }

        [Fact]
        public async Task Get_RecuperarPedidoProdutosPorPedidoAsync_Failure_IdInvalido()
        {
            //Arrange
            var IdPedido = Guid.Empty;
            var client = _factory.CreateClient();
            var url = $"api/PedidosProdutros/{IdPedido}";
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
