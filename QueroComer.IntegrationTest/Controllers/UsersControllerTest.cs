using QueroComer.Entidades.Entidades;
using System.Net;
using System.Net.Http.Headers;

namespace QueroComer.IntegrationTest.Controllers
{
    public class UsersControllerTest : BaseTest, IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public UsersControllerTest(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        #region RecuperarUsuarioAsync

        [Theory]
        [InlineData("09a80dee-f695-481b-ac43-ba6538f89c8e")]
        public async Task Get_RecuperarUsuarioAsync_Success(string Id)
        {
            //Arrange
            var client = _factory.CreateClient();
            var url = $"api/Users/{Id}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType!.ToString());
        }

        [Theory]
        [InlineData("09a80dee-f695-481b-ac43-ba6538f89c89")]
        public async Task Get_RecuperarUsuarioAsync_Failuure_NotFound(string Id)
        {
            //Arrange
            var client = _factory.CreateClient();
            var url = $"api/Users/{Id}";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Get_RecuperarUsuarioAsync_Failuure_IdInvalido()
        {
            //Arrange
            var Id = Guid.Empty;
            var client = _factory.CreateClient();
            var url = $"api/Users/{Id}";
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
