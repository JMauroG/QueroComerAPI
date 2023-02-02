using NSubstitute;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Interfaces;
using QueroComer.Mock.Entidades;
using QueroComer.Services;

namespace QueroComer.UnitTest.Services
{
    public class PedidoProdutoServiceTest
    {
        private readonly IPedidoProdutoRepository _repositoryMock;
        private readonly IPedidoProdutoService _serviceMock;

        public PedidoProdutoServiceTest()
        {
            _repositoryMock = Substitute.For<IPedidoProdutoRepository>();
            _serviceMock = new PedidoProdutoService(_repositoryMock);
        }

        [Fact]
        public async Task PedidoProduto_CadastrarPedidoProdutoPorIdAsync_Success()
        {
            //Arrange
            PedidoProduto pedidoProdutoMock = PedidoProdutoMock.GetPedidoProdutoMock();

            //Act
            var actualPedidoProduto = await _serviceMock.CadastrarPedidoProdutoAsync(pedidoProdutoMock);

            //Assert
            Assert.Equal(pedidoProdutoMock, actualPedidoProduto);
        }

        [Fact]
        public async Task PedidoProduto_RecuperarPedidoProdutoPorIdAsync_Success()
        {
            //Arrange
            PedidoProduto pedidoProdutoMock = PedidoProdutoMock.GetPedidoProdutoMock();
            _repositoryMock.RecuperarPedidoProdutoPorIdAsync(pedidoProdutoMock.Id).Returns(pedidoProdutoMock);

            //Act
            var actualPedidoProduto = await _serviceMock.RecuperarPedidoProdutoPorIdAsync(pedidoProdutoMock.Id);

            //Assert
            Assert.Equal(pedidoProdutoMock, actualPedidoProduto);
        }

        [Fact]
        public async Task PedidoProduto_RecuperarPedidoProdutosPorPedidoAsync_Success()
        {
            //Arrange
            Pedido pedidoMock = PedidoMock.GetPedidoMock();
            List<PedidoProduto> listPedidoProdutoMock = PedidoProdutoMock.GetPedidoProdutoListMock(pedidoMock);
            _repositoryMock.RecuperarPedidoProdutosPorPedidoAsync(pedidoMock.Id).Returns(listPedidoProdutoMock);

            //Act
            var actualPedidoProdutoList = await _serviceMock.RecuperarPedidoProdutosPorPedidoAsync(pedidoMock.Id);

            //Assert
            Assert.Equal(listPedidoProdutoMock.Count, actualPedidoProdutoList.Count);
            Assert.True(actualPedidoProdutoList.All(x => x.PedidoId.Equals(pedidoMock.Id)));
        }

        [Fact]
        public async Task PedidoProduto_AtualizarQuantidadePedidoProdutoAsync_Success()
        {
            //Arrange
            PedidoProduto pedidoProdutoMock = PedidoProdutoMock.GetPedidoProdutoMock();
            pedidoProdutoMock.Quantidade = 23;
            _repositoryMock.AtualizarQuantidadePedidoProdutoAsync(pedidoProdutoMock).Returns(pedidoProdutoMock);

            //Act
            var actualPedidoProduto = await _serviceMock.AtualizarQuantidadePedidoProdutoAsync(pedidoProdutoMock);

            //Assert
            Assert.Equal(pedidoProdutoMock, actualPedidoProduto);
        }
    }
}
