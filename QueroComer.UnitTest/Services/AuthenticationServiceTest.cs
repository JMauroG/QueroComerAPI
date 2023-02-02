using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Enumerables;
using QueroComer.Entidades.Interfaces;
using QueroComer.Mock.Entidades;
using QueroComer.Services;

namespace QueroComer.UnitTest.Services
{
    public class AuthenticationServiceTest
    {
        private readonly IAuthenticationService _serviceMock;
        private readonly IUserRepository _userRepositoryMock;
        private readonly UserManager<IdentityUser> _userManagerMock;
        private readonly IConfiguration _configurationMock;
        private readonly IUserStore<IdentityUser> _userStoreMock;
        private readonly IPasswordHasher<IdentityUser> _passwordHasherMock;

        public AuthenticationServiceTest()
        {
            var inMemorySettings = new Dictionary<string, string> {
                    {"Jwt:Key", "chaveSuperSecretaDoJwt"},
                    {"Jwt:Issuer", "AlgumIssuer"},
                    {"Jwt:Audience", "AlgumaAudience"},
            };
            _userRepositoryMock = Substitute.For<IUserRepository>();
            _configurationMock = new ConfigurationBuilder()
                .AddInMemoryCollection(initialData: inMemorySettings!)
                .Build();
            _userStoreMock = Substitute.For<IUserStore<IdentityUser>>();
            _passwordHasherMock = Substitute.For<IPasswordHasher<IdentityUser>>();
            _userManagerMock = new UserManager<IdentityUser>(_userStoreMock, null!, _passwordHasherMock, null!, null!, null!, null!, null!, null!);
            _serviceMock = new AuthenticationService(_userRepositoryMock, _configurationMock, _userManagerMock);
        }

        [Fact]
        public async Task Authentication_LoginAsync_Success()
        {
            //Arrange
            Login loginMock = LoginMock.GetLoginDTOMock();
            IdentityUser userMock = UserMock.GetUserMock();
            _userRepositoryMock.RetornaUsuarioPorEmailAsync(loginMock.Email!).Returns(userMock);
            _userManagerMock.PasswordHasher.VerifyHashedPassword(userMock, userMock.PasswordHash!, loginMock.Password!).Returns(PasswordVerificationResult.Success);

            //Act
            RespostaLogin actualRespostaLogin = await _serviceMock.LoginAsync(loginMock);

            //Assert
            Assert.Equal(loginMock.Email, actualRespostaLogin.Email);
            Assert.NotEmpty(actualRespostaLogin.Token!);
            Assert.Equal(userMock.Id, actualRespostaLogin.IdUsuario);
        }

        [Fact]
        public async Task Authentication_LoginAsync_Failure_NotFound()
        {
            //Arrange
            Login loginMock = LoginMock.GetLoginDTOMock();

            //Act
            RespostaLogin actualRespostaLogin = await _serviceMock.LoginAsync(loginMock);

            //Assert
            Assert.Equal(EStatusCode.NotFound, actualRespostaLogin.StatusCode);
        }

        [Fact]
        public async Task Authentication_LoginAsync_Failure_Unauthorized()
        {
            //Arrange
            Login loginMock = LoginMock.GetLoginDTOMock();
            IdentityUser userMock = UserMock.GetUserMock();
            _userRepositoryMock.RetornaUsuarioPorEmailAsync(loginMock.Email!).Returns(userMock);
            _userManagerMock.PasswordHasher.VerifyHashedPassword(userMock, userMock.PasswordHash!, loginMock.Password!).Returns(PasswordVerificationResult.Failed);

            //Act
            RespostaLogin actualRespostaLogin = await _serviceMock.LoginAsync(loginMock);

            //Assert
            Assert.Empty(actualRespostaLogin.Email!);
            Assert.Empty(actualRespostaLogin.Token!);
            Assert.Equal(EStatusCode.Unauthorized, actualRespostaLogin.StatusCode);
        }

    }
}
