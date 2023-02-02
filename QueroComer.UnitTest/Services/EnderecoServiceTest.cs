using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NSubstitute;
using QueroComer.DTO.Endereco;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Interfaces;
using QueroComer.Mock.DTO.Endereco;
using QueroComer.Mock.Entidades;
using QueroComer.Profiles;
using QueroComer.Services;

namespace QueroComer.UnitTest.Services
{
    public class EnderecoServiceTest
    {
        private readonly IEnderecoRepository _repositoryMock;
        private readonly IEnderecoService _serviceMock;
        private readonly IUserRepository _userRepositoryMock;
        private readonly IMapper _mapper;

        public EnderecoServiceTest()
        {
            var mapperProfile = new MapperProfile();
            var configuration = new MapperConfiguration(x => x.AddProfile(mapperProfile));
            _mapper = new Mapper(configuration);

            _repositoryMock = Substitute.For<IEnderecoRepository>();
            _userRepositoryMock = Substitute.For<IUserRepository>();
            _serviceMock = new EnderecoService(_repositoryMock, _userRepositoryMock, _mapper);
        }


        [Fact]
        public async Task Endereco_CadastroEnderecoAsync_Success()
        {
            //Arrange
            IdentityUser userMock = UserMock.GetUserMock();
            CreateEnderecoDTO createEnderecoDTOMock = CreateEnderecoDTOMock.GetCreateEnderecoDTOMock();
            _userRepositoryMock.RetornaUsuarioPorIdAsync(userMock.Id).Returns(userMock);

            //Act
            Endereco enderecoMock = _mapper.Map<Endereco>(createEnderecoDTOMock);
            var actualEndereco = await _serviceMock.CadastrarEnderecoAsync(userMock.Id, enderecoMock);

            //Assert
            Assert.Equal(createEnderecoDTOMock.Rua, actualEndereco.Rua);
            Assert.Equal(createEnderecoDTOMock.Numero, actualEndereco.Numero);
            Assert.Equal(createEnderecoDTOMock.Complemento, actualEndereco.Complemento);
            Assert.Equal(createEnderecoDTOMock.Bairro, actualEndereco.Bairro);
            Assert.Equal(createEnderecoDTOMock.CEP, actualEndereco.CEP);
            Assert.Equal(createEnderecoDTOMock.UF, actualEndereco.UF);
            Assert.Equal(createEnderecoDTOMock.Cidade, actualEndereco.Cidade);
            Assert.Equal(createEnderecoDTOMock.Pais, actualEndereco.Pais);
            Assert.Equal(userMock.Id, actualEndereco.Usuario!.Id);
        }

        [Fact]
        public async Task Endereco_RecuperarEnderecoPorIdAsync_Success()
        {
            //Arrange
            Endereco enderecoMock = EnderecoMock.GetEnderecoMock();
            _repositoryMock.RecuperarEnderecoPorIdAsync(enderecoMock.Id).Returns(enderecoMock);

            //Act
            var actualEndereco = await _serviceMock.RecuperarEnderecoPorIdAsync(enderecoMock.Id);

            //Assert
            Assert.Equal(enderecoMock, actualEndereco);
        }

        [Fact]
        public async Task Endereco_RecuperarEnderecosPorUsuarioAsync_Success()
        {
            //Arrange
            IdentityUser userMock = UserMock.GetUserMock();
            List<Endereco> listEnderecoMock = EnderecoMock.GetListEnderecoMock();
            listEnderecoMock = listEnderecoMock.Where(x => x.IdUsuario == userMock.Id).ToList();
            _userRepositoryMock.RetornaUsuarioPorIdAsync(userMock.Id).Returns(userMock);
            _repositoryMock.RecuperarEnderecosPorUsuarioAsync(userMock).Returns(listEnderecoMock);

            //Act
            var actualEnderecoList = await _serviceMock.RecuperarEnderecosPorUsuarioAsync(userMock.Id);

            //Assert
            Assert.Equal(listEnderecoMock.Count, actualEnderecoList.Count);
            Assert.True(actualEnderecoList.All(x => x.IdUsuario.Equals(userMock.Id)));
        }


    }
}
