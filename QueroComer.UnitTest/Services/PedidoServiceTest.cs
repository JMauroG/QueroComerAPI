using Microsoft.AspNetCore.Identity;
using NSubstitute;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Enumerables;
using QueroComer.Entidades.Interfaces;
using QueroComer.Mock.Entidades;
using QueroComer.Services;

namespace QueroComer.UnitTest.Services
{
    public class PedidoServiceTest
    {
        private readonly IPedidoRepository _repositoryMock;
        private readonly IEnderecoRepository _enderecoRepositoryMock;
        private readonly IPedidoService _serviceMock;

        public PedidoServiceTest()
        {
            _repositoryMock = Substitute.For<IPedidoRepository>();
            _enderecoRepositoryMock = Substitute.For<IEnderecoRepository>();
            _serviceMock = new PedidoService(_repositoryMock, _enderecoRepositoryMock);
        }

        [Fact]
        public async Task PedidoService_CadastrarPedidoAsync_Success()
        {
            //Arrange
            Pedido pedidoMock = PedidoMock.GetPedidoMock();

            //Act
            var actualPedido = await _serviceMock.CadastrarPedidoAsync(pedidoMock);

            //Assert
            Assert.Equal(pedidoMock, actualPedido);
        }

        [Fact]
        public async Task PedidoService_RecuperarPedidoPorIdAsync_Success()
        {
            //Arrange
            Pedido pedidoMock = PedidoMock.GetPedidoMock();
            _repositoryMock.RecuperarPedidoPorIdAsync(pedidoMock.Id).Returns(pedidoMock);

            //Act
            var actualPedido = await _serviceMock.RecuperarPedidoPorIdAsync(pedidoMock.Id);

            //Assert
            Assert.Equal(pedidoMock, actualPedido);
        }

        [Fact]
        public async Task PedidoService_RecuperarPedidosPorUserAsync_Success() 
        {
            //Arrange
            IdentityUser userMock = UserMock.GetUserMock();
            List<Pedido> listPedidoMock = PedidoMock.GetPedidoListMock();
            _repositoryMock.RecuperarPedidosPorUserAsync(userMock.Id).Returns(listPedidoMock);

            //Act
            var actualPedidos = await _serviceMock.RecuperarPedidosPorUserAsync(userMock.Id);

            //Assert
            Assert.Equal(listPedidoMock.Count, actualPedidos.Count);
            Assert.True(actualPedidos.All(x => x.UserId.Equals(userMock.Id)));
        }

        [Fact]
        public async Task PedidoService_AtualizarStatusPedidoAsync_Success()
        {
            //Arrange
            Pedido pedidoMock = PedidoMock.GetPedidoMock();
            pedidoMock.Status = EStatusPedido.ACaminho;
            _repositoryMock.AtualizarStatusPedidoAsync(pedidoMock).Returns(pedidoMock);

            //Act
            var actualPedido = await _serviceMock.AtualizarStatusPedidoAsync(pedidoMock);

            //Assert
            Assert.Equal(pedidoMock.Status, actualPedido.Status);
        }

    }
}
