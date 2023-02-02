using QueroComer.Data.Repositories;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Interfaces;
using QueroComer.Mock;
using QueroComer.Mock.Entidades;

namespace QueroComer.UnitTest.Repositories
{
    public class ProdutoRepositoryTest
    {
        [Fact]
        public async Task ProdutoRepository_CadastrarProdutoAsync_Success()
        {
            //Arrange
            Produto produtoMock = ProdutoMock.GetProdutoMock();
            var contextMock = new InMemoryDbContextFactory().GetDbContext("CadastrarProdutoAsyncTest");
            var produtoRespositoryMock = new ProdutoRepository(contextMock);

            //Act
            await produtoRespositoryMock.CadastrarProdutoAsync(produtoMock);
            var produtos = produtoRespositoryMock.GetEnumerable();

            //Assert
            Assert.Contains(produtoMock, produtos);
        }

        [Fact]
        public async Task ProdutoRepository_RecuperarProdutoPorIdAsync_Success()
        {
            //Arrange
            Produto produtoMock = ProdutoMock.GetProdutoMock();
            var contextMock = new InMemoryDbContextFactory().GetDbContext("RecuperarProdutoPorIdAsyncTest");
            await contextMock.Produtos.AddAsync(produtoMock);
            await contextMock.SaveChangesAsync();
            var produtoRespositoryMock = new ProdutoRepository(contextMock);

            //act
            var actualProduto = await produtoRespositoryMock.RecuperarProdutoPorIdAsync(produtoMock.Id);

            //Assert
            Assert.Equal(produtoMock.Id, actualProduto.Id);
        }

        [Fact]
        public async Task ProdutoRepository_RecuperarProdutosPorRestauranteAsync_Success()
        {
            //Arrange
            Restaurante restauranteMock = RestauranteMock.GetRestauranteMock();
            List<Produto> listProdutosMock = ProdutoMock.GetProdutoListMock(restauranteMock);
            var contextMock = new InMemoryDbContextFactory().GetDbContext("RecuperarProdutosPorRestauranteAsyncTest");
            await contextMock.Restaurantes.AddAsync(restauranteMock);
            await contextMock.Produtos.AddRangeAsync(listProdutosMock);
            await contextMock.SaveChangesAsync();
            var produtoRespositoryMock = new ProdutoRepository(contextMock);

            //act
            var actualProdutos = await produtoRespositoryMock.RecuperarProdutosPorRestauranteAsync(restauranteMock.Id);

            //Assert
            Assert.Equal(listProdutosMock.Count, actualProdutos.Count);
            Assert.True(actualProdutos.All(x => x.Restaurante.Id.Equals(restauranteMock.Id)));
        }
    }
}
