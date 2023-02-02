using QueroComer.Data.Repositories;
using QueroComer.Entidades.Entidades;
using QueroComer.Mock;
using QueroComer.Mock.Entidades;

namespace QueroComer.UnitTest.Repositories
{
    public class EnderecoRepositoryTest
    {
        [Fact]
        public async Task EnderecoRepository_CadastrarEnderecoAsync_Success()
        {
            //Arrange
            var contextMock = new InMemoryDbContextFactory().GetDbContext("CadastrarEnderecoAsyncTest");
            var enderecoRepositoryMock = new EnderecoRepository(contextMock);
            Endereco enderecoMock = EnderecoMock.GetEnderecoMock();

            //Act
            await enderecoRepositoryMock.CadastrarEnderecoAsync(enderecoMock);
            var enderecos = enderecoRepositoryMock.GetEnumerable();

            //Assert
            Assert.Contains(enderecoMock, enderecos);
        }

        [Fact]
        public async Task EnderecoRepository_RecuperarEnderecoPorIdAsync_Success()
        {
            //Arrange
            Endereco enderecoMock = EnderecoMock.GetEnderecoMock();
            var contextMock = new InMemoryDbContextFactory().GetDbContext("RecuperarEnderecoPorIdAsyncTest");
            await contextMock.AddAsync(enderecoMock);
            await contextMock.SaveChangesAsync();
            var enderecoRepositoryMock = new EnderecoRepository(contextMock);

            //Act
            var actualEndereco = await enderecoRepositoryMock.RecuperarEnderecoPorIdAsync(enderecoMock.Id);

            //Assert
            Assert.Equal(enderecoMock.Id, actualEndereco.Id);
        }
    }
}
