using System.Net;
using System.Net.Http.Headers;

namespace QueroComer.IntegrationTest.Controllers
{
    public class PedidosControllerTest : BaseTest, IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public PedidosControllerTest(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        #region RecuperarPedidoPorIdAsync
        [Theory]
        [InlineData("aa6caffd-d52f-4db4-9b89-781a98d8ebbc")]
        public async Task Get_RecuperarPedidoPorIdAsync_Success(Guid IdPedido)
        {
            //Arrange
            var client = _factory.CreateClient();
            var url = $"api/Pedidos/{IdPedido}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType!.ToString());
        }

        [Theory]
        [InlineData("aa6caffd-d52f-4db4-9b89-781a98d8eabc")]
        public async Task Get_RecuperarPedidoPorIdAsync_Failure_NotFound(Guid IdPedido)
        {
            //Arrange
            var client = _factory.CreateClient();
            var url = $"api/Pedidos/{IdPedido}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Get_RecuperarPedidoPorIdAsync_Failure_IdInvalido()
        {
            //Arrange
            var IdPedido = Guid.Empty;
            var client = _factory.CreateClient();
            var url = $"api/Pedidos/{IdPedido}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        #endregion

        #region RecuperarPedidoPorUserAsync
        [Theory]
        [InlineData("09a80dee-f695-481b-ac43-ba6538f89c8e")]
        public async Task Get_RecuperarPedidoPorUserAsync_Success(String IdUser)
        {
            //Arrange
            var client = _factory.CreateClient();
            var url = $"api/Pedidos/User/{IdUser}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType!.ToString());
        }

        [Theory]
        [InlineData("a4cfd26e-a2e1-429a-92e7-8f391ee07722")]
        public async Task Get_RecuperarPedidoPorUserAsync_Failure_NotFound(String IdUser)
        {
            //Arrange
            var client = _factory.CreateClient();
            var url = $"api/Pedidos/User/{IdUser}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Get_RecuperarPedidoPorUserAsync_Failure_IdInvalido()
        {
            //Arrange
            var IdUser = Guid.Empty;
            var client = _factory.CreateClient();
            var url = $"api/Pedidos/User/{IdUser}";
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
