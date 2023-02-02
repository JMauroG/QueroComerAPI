using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NSubstitute;
using QueroComer.DTO.User;
using QueroComer.Entidades.Interfaces;
using QueroComer.Mock.DTO.User;
using QueroComer.Mock.Entidades;
using QueroComer.Profiles;
using QueroComer.Services;

namespace QueroComer.UnitTest.Services
{
    public class UserServiceTest
    {
        private readonly IUserService _serviceMock;
        private readonly IUserRepository _repositoryMock;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManagerMock;
        private readonly IUserStore<IdentityUser> _userStoreMock;
        private readonly IPasswordHasher<IdentityUser> _passwordHasherMock;

        public UserServiceTest()
        {
            var mapperProfile = new MapperProfile();
            var configuration = new MapperConfiguration(x => x.AddProfile(mapperProfile));
            _mapper = new Mapper(configuration);

            _passwordHasherMock = Substitute.For<IPasswordHasher<IdentityUser>>();
            _userStoreMock = Substitute.For<IUserStore<IdentityUser>>();
            _userManagerMock = new UserManager<IdentityUser>(_userStoreMock, null, _passwordHasherMock, null, null, null, null, null, null);
            _repositoryMock = Substitute.For<IUserRepository>();
            _serviceMock = new UserService(_repositoryMock, _userManagerMock);
        }

        [Fact]
        public async Task User_RetornaUsuarioPorIdAsync_Success()
        {
            //Arrange
            IdentityUser userMock = UserMock.GetUserMock();
            _repositoryMock.RetornaUsuarioPorIdAsync(userMock.Id).Returns(userMock);

            //Act
            var actualUser = await _serviceMock.RetornaUsuarioPorIdAsync(userMock.Id);

            //Assert
            Assert.Equal(userMock, actualUser);
            Assert.IsType<IdentityUser>(actualUser);
        }

        [Fact]
        public async Task User_RetornaUsuarioPorEmailAsync_Success()
        {
            //Arrange
            IdentityUser userMock = UserMock.GetUserMock();
            _repositoryMock.RetornaUsuarioPorEmailAsync(userMock.Email).Returns(userMock);

            //Act
            var actualUser = await _serviceMock.RetornaUsuarioPorEmailAsync(userMock.Email);

            //Assert
            Assert.Equal(userMock, actualUser);
            Assert.IsType<IdentityUser>(actualUser);
        }

        [Fact]
        public async Task User_CadastrarUsuarioAsync_Success()
        {
            //Arrange
            CreateUserDTO createUserDTOMock = CreateUserDTOMock.GetCreateUserDTOMock();
            IdentityUser novoUserMock = new IdentityUser
            {
                Email = createUserDTOMock.Email,
                UserName = createUserDTOMock.Nome
            };
            _userManagerMock.CreateAsync(novoUserMock).Returns(IdentityResult.Success);

            //Act
            var actualResposta = await _serviceMock.CadastrarUsuarioAsync(novoUserMock);

            //Assert
            Assert.True(actualResposta.Sucesso);
        }

        [Fact]
        public async Task User_CadastrarUsuarioAsync_Failure_EmailVazio()
        {
            //Arrange
            CreateUserDTO createUserDTOMock = CreateUserDTOMock.GetCreateUserDTOMock();
            IdentityUser novoUserMock = new IdentityUser
            {
                Email = "",
                UserName = createUserDTOMock.Nome
            };
            _userManagerMock.CreateAsync(novoUserMock).Returns(IdentityResult.Failed(new IdentityError { Description = "Email '' is invalid." }));

            //Act
            var actualResposta = await _serviceMock.CadastrarUsuarioAsync(novoUserMock);

            //Assert
            Assert.False(actualResposta.Sucesso);
            Assert.Contains("Email '' is invalid.", actualResposta.ListaDeErros);
        }

        [Fact]
        public async Task User_CadastrarUsuarioAsync_Failure_UsernameVazio()
        {
            //Arrange
            CreateUserDTO createUserDTOMock = CreateUserDTOMock.GetCreateUserDTOMock();
            IdentityUser novoUserMock = new IdentityUser
            {
                Email = "ncjuninho@hotmail.com",
                UserName = ""
            };
            _userManagerMock.CreateAsync(novoUserMock).Returns(IdentityResult.Failed(new IdentityError { Description = "UserName '' is invalid." }));

            //Act
            var actualResposta = await _serviceMock.CadastrarUsuarioAsync(novoUserMock);

            //Assert
            Assert.False(actualResposta.Sucesso);
            Assert.Contains("UserName '' is invalid.", actualResposta.ListaDeErros);
        }
    }
}
