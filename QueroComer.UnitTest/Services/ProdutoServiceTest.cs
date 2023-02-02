using AutoMapper;
using NSubstitute;
using QueroComer.DTO.Produto;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Interfaces;
using QueroComer.Mock.DTO.Produto;
using QueroComer.Mock.Entidades;
using QueroComer.Profiles;
using QueroComer.Services;

namespace QueroComer.UnitTest.Services
{
    public class ProdutoServiceTest
    {
        private readonly IProdutoRepository _repositoryMock;
        private readonly IProdutoService _serviceMock;
        private readonly IMapper _mapper;
        public ProdutoServiceTest()
        {
            var mapperProfile = new MapperProfile();
            var configuration = new MapperConfiguration(x => x.AddProfile(mapperProfile));
            _mapper = new Mapper(configuration);

            _repositoryMock = Substitute.For<IProdutoRepository>();
            _serviceMock = new ProdutoService(_repositoryMock, _mapper);
        }

        [Fact]
        public async Task Produto_CadastrarProdutoAsync_Success()
        {
            //Arrange
            CreateProdutoDTO createProdutoDTOMock = CreateProdutoDTOMock.GetCreateProdutoDTO();
            Produto produtoMock = _mapper.Map<Produto>(createProdutoDTOMock);

            //Act
            var actualProduto = await _serviceMock.CadastrarProdutoAsync(produtoMock);

            //Assert
            Assert.Equal(produtoMock, actualProduto);
        }

        [Fact]
        public async Task Produto_RecuperarProdutoPorIdAsync_Success()
        {
            //Arrange
            Produto produtoMock = ProdutoMock.GetProdutoMock();
            _repositoryMock.RecuperarProdutoPorIdAsync(produtoMock.Id).Returns(produtoMock);

            //Act
            var actualProduto = await _serviceMock.RetornarProdutoPorIdAsync(produtoMock.Id);

            //Assert
            Assert.Equal(produtoMock, actualProduto);
        }

        [Fact]
        public async Task Produto_RecuperarProdutoPorRestauranteAsync_Success()
        {
            //Arrange
            Restaurante restauranteMock = RestauranteMock.GetRestauranteMock();
            List<Produto> listProdutoMock = ProdutoMock.GetProdutoListMock(restauranteMock);
            _repositoryMock.RecuperarProdutosPorRestauranteAsync(restauranteMock.Id).Returns(listProdutoMock);

            //Act
            var actualProdutoList = await _serviceMock.RetornarProdutosPorRestauranteAsync(restauranteMock.Id);

            //Assert
            Assert.Equal(listProdutoMock.Count, actualProdutoList.Count);
            Assert.True(actualProdutoList.All(x => x.RestauranteId.Equals(restauranteMock.Id)));
        }
    }
}
