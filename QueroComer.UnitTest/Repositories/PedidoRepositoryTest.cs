using Microsoft.AspNetCore.Identity;
using QueroComer.Data.Repositories;
using QueroComer.DTO.Pedido;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Enumerables;
using QueroComer.Mock;
using QueroComer.Mock.DTO.Pedido;
using QueroComer.Mock.Entidades;

namespace QueroComer.UnitTest.Repositories
{
    public class PedidoRepositoryTest
    {
        [Fact]
        public async Task PedidoRepository_CadastrarProdutoAsync_Sucess()
        {
            //Arrange
            Pedido pedidoMock = PedidoMock.GetPedidoMock();
            var contextMock = new InMemoryDbContextFactory().GetDbContext("CadastrarPedidoAsyncTest");
            var pedidoRepositoryMock = new PedidoRepository(contextMock);

            //Act
            await pedidoRepositoryMock.CadastrarPedidoAsync(pedidoMock);
            var pedidos = pedidoRepositoryMock.GetEnumerable();

            //Assert
            Assert.Contains(pedidoMock, pedidos);
        }

        [Fact]
        public async Task PedidoRepository_RecuperarPedidoPorIdAsync_Sucess()
        {
            //Arrange
            Pedido pedidoMock = PedidoMock.GetPedidoMock();
            var contextMock = new InMemoryDbContextFactory().GetDbContext("RecuperarPedidoPorIdAsyncTest");
            await contextMock.Pedidos.AddAsync(pedidoMock);
            await contextMock.SaveChangesAsync();
            var pedidoRepositoryMock = new PedidoRepository(contextMock);

            //Act
            var actualProduto = await pedidoRepositoryMock.RecuperarPedidoPorIdAsync(pedidoMock.Id);

            //Assert
            Assert.Equal(pedidoMock, actualProduto);
        }

        [Fact]
        public async Task PedidoRepository_RecuperarPedidosPorUserAsync_Sucess()
        {
            //Arrange
            IdentityUser user = UserMock.GetUserMock();
            List<Pedido> listPedidoMock = PedidoMock.GetPedidoListMock();
            var contextMock = new InMemoryDbContextFactory().GetDbContext("RecuperarPedidosPorUserAsyncTest");
            await contextMock.Pedidos.AddRangeAsync(listPedidoMock);
            await contextMock.SaveChangesAsync();
            var pedidoRepositoryMock = new PedidoRepository(contextMock);

            //Act
            var actualPedidos = await pedidoRepositoryMock.RecuperarPedidosPorUserAsync(user.Id);

            //Assert
            Assert.Equal(listPedidoMock.Count, actualPedidos.Count);
            Assert.True(actualPedidos.All(x => x.UserId.Equals(user.Id)));
        }

        [Fact]
        public async Task PedidoRepository_AtualizaStatusPedidoAsync_Success()
        {
            //Arrange
            Pedido pedidoMock = PedidoMock.GetPedidoMock();
            pedidoMock.Status = EStatusPedido.Aceito;
            var contextMock = new InMemoryDbContextFactory().GetDbContext("AtualizaStatusPedidoAsync");
            await contextMock.Pedidos.AddAsync(pedidoMock);
            await contextMock.SaveChangesAsync();


            var pedidoRepositoryMock = new PedidoRepository(contextMock);

            //Act
            var actualPedido = await pedidoRepositoryMock.AtualizarStatusPedidoAsync(pedidoMock);

            //Assert
            Assert.Equal(pedidoMock, actualPedido);
        }
    }
}
