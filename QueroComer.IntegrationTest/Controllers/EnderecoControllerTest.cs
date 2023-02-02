using System.Net;
using System.Net.Http.Headers;

namespace QueroComer.IntegrationTest.Controllers
{
    public class EnderecoControllerTest : BaseTest, IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public EnderecoControllerTest(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("09a80dee-f695-481b-ac43-ba6538f89c8e")]
        [InlineData("a4cfd26e-a2e1-429a-92e7-8f391ee07722")]
        public async Task Get_EnderecosPorUsuarioAsync_Success(string IdUsuario)
        {
            //Arrange
            var client = _factory.CreateClient();
            var url = $"api/Enderecos/Usuario/{IdUsuario}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType!.ToString());
        }

        [Theory]
        [InlineData("e85380fc-764a-4605-ad12-e9685ddadacc")]
        [InlineData("9e124f84-cd46-4ac1-8ad1-426ebeb57f88")]
        public async Task Get_EnderecosPorUsuarioAsync_Failure_NotFound(string IdUsuario)
        {
            //Arrange
            var client = _factory.CreateClient();
            var url = $"api/Enderecos/Usuario/{IdUsuario}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Get_EnderecosPorUsuarioAsync_Failure_BadRequest_IdInvalido()
        {
            //Arrange
            var IdUsuario = Guid.Empty;
            var client = _factory.CreateClient();
            var url = $"api/Enderecos/Usuario/{IdUsuario}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [InlineData("b8c10a11-32fe-41fc-b8a6-c0966ed85415")]
        [InlineData("90e52aef-ebd0-470d-a1f2-0646658effde")]
        [InlineData("8309174a-54e6-44af-9684-483708bdf694")]
        [InlineData("90b6548b-4cd0-4e7b-b10a-9c33bd958142")]
        public async Task Get_RecuperarEnderecoPorIdAsync_Success(string EnderecoId)
        {
            //Arrange
            var client = _factory.CreateClient();
            var url = $"api/Enderecos/{EnderecoId}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType!.ToString());
        }

        [Fact]
        public async Task Get_RecuperarEnderecoPorIdAsync_Failure_BadRequest_IdInvalido()
        {
            //Arrange
            var EnderecoId = Guid.Empty;
            var client = _factory.CreateClient();
            var url = $"api/Enderecos/{EnderecoId}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Get_RecuperarEnderecoPorIdAsync_Failure_NotFound()
        {
            //Arrange
            var EnderecoId = Guid.NewGuid();
            var client = _factory.CreateClient();
            var url = $"api/Enderecos/{EnderecoId}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }


    }
}
