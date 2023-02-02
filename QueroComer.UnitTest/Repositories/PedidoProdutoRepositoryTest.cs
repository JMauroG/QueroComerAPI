using NSubstitute.Extensions;
using QueroComer.Data.Repositories;
using QueroComer.Entidades.Entidades;
using QueroComer.Mock;
using QueroComer.Mock.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueroComer.UnitTest.Repositories
{
    public class PedidoProdutoRepositoryTest
    {
        [Fact]
        public async Task PedidoProdutoRepository_CadastrarPedidoProdutoAsync_Success()
        {
            //Arrange
            PedidoProduto pedidoProdutoMock = PedidoProdutoMock.GetPedidoProdutoMock();
            var contextMock = new InMemoryDbContextFactory().GetDbContext("CadastrarPedidoProdutoAsyncTest");
            var pedidoProdutoRepositoryMock = new PedidoProdutoRepository(contextMock);

            //Act
            await pedidoProdutoRepositoryMock.CadastrarPedidoProdutoAsync(pedidoProdutoMock);
            var pedidoProdutos = pedidoProdutoRepositoryMock.GetEnumerable();

            //Assert
            Assert.Contains(pedidoProdutoMock, pedidoProdutos);
        }

        [Fact]
        public async Task PedidoProdutoRepository_RecuperarPedidoProdutoPorIdAsync_Success()
        {
            //Arrange
            PedidoProduto pedidoProdutoMock = PedidoProdutoMock.GetPedidoProdutoMock();
            var contextMock = new InMemoryDbContextFactory().GetDbContext("RecuperarPedidoProdutoPorIdAsyncTest");
            await contextMock.PedidosProdutos.AddAsync(pedidoProdutoMock);
            await contextMock.SaveChangesAsync();
            var pedidoProdutoRepositoryMock = new PedidoProdutoRepository(contextMock);

            //Act
            var actualPedidoProduto = await pedidoProdutoRepositoryMock.RecuperarPedidoProdutoPorIdAsync(pedidoProdutoMock.Id);

            //Assert
            Assert.Equal(pedidoProdutoMock.Id, actualPedidoProduto.Id);
        }

        [Fact]
        public async Task PedidoProdutoRepository_RecuperarPedidoProdutosPorPedidoAsync_Success()
        {
            //Arrange
            Pedido pedidoMock = PedidoMock.GetPedidoMock();
            List<PedidoProduto> listPedidoProdutoMock = PedidoProdutoMock.GetPedidoProdutoListMock(pedidoMock);
            var contextMock = new InMemoryDbContextFactory().GetDbContext("RecuperarPedidoProdutosPorPedidoAsyncTest");
            await contextMock.PedidosProdutos.AddRangeAsync(listPedidoProdutoMock);
            await contextMock.SaveChangesAsync();
            var pedidoProdutoRepositoryMock = new PedidoProdutoRepository(contextMock);

            //Act
            var actualPedidoProdutos = await pedidoProdutoRepositoryMock.RecuperarPedidoProdutosPorPedidoAsync(pedidoMock.Id);

            //Assert
            Assert.Equal(listPedidoProdutoMock.Count, actualPedidoProdutos.Count);
            Assert.True(actualPedidoProdutos.All(x => x.PedidoId.Equals(pedidoMock.Id)));
        }

        [Fact]
        public async Task PedidoProdutoRepository_AtualizarQuantidadePedidoProdutoAsync_Success()
        {
            //Arrange
            PedidoProduto pedidoProdutoMock = PedidoProdutoMock.GetPedidoProdutoMock();
            var contextMock = new InMemoryDbContextFactory().GetDbContext("AtualizarQuantidadePedidoProdutoAsync");
            await contextMock.PedidosProdutos.AddAsync(pedidoProdutoMock);
            await contextMock.SaveChangesAsync();
            var pedidoProdutoRepositoryMock = new PedidoProdutoRepository(contextMock);
            pedidoProdutoMock.Quantidade = 4;

            //Act
            var actualPedidoProduto = await pedidoProdutoRepositoryMock.AtualizarQuantidadePedidoProdutoAsync(pedidoProdutoMock);

            //Assert
            Assert.Equal(pedidoProdutoMock, actualPedidoProduto);
        }

        [Fact]
        public async Task PedidoProdutoRepository_RemoverPedidoProdutoAsync_Success()
        {
            //Arrange
            PedidoProduto pedidoProdutoMock = PedidoProdutoMock.GetPedidoProdutoMock();
            var contextMock = new InMemoryDbContextFactory().GetDbContext("RemoverPedidoProduto");
            await contextMock.PedidosProdutos.AddAsync(pedidoProdutoMock);
            await contextMock.SaveChangesAsync();
            var pedidoProdutoRepositoryMock = new PedidoProdutoRepository(contextMock);

            //Act
            await pedidoProdutoRepositoryMock.RemoverPedidoProdutoAsync(pedidoProdutoMock);
            var pedidosProdutosMock = pedidoProdutoRepositoryMock.GetEnumerable();

            //Assert
            Assert.True(pedidosProdutosMock.All(x => !x.Id.Equals(pedidoProdutoMock.Id)));
        }
    }
}
