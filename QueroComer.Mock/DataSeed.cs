using QueroComer.Data;
using QueroComer.Mock.Entidades;

namespace QueroComer.Mock
{
    public class DataSeed
    {
        public static void Seed(AppDbContext _context)
        {
            #region Mocks
            var Enderecos = EnderecoMock.GetListEnderecoMock();
            var Pedidos = PedidoMock.GetPedidoListMock();
            var PedidosProdutos = PedidoProdutoMock.GetPedidoProdutoListMock(PedidoMock.GetPedidoMock());
            var Produtos = ProdutoMock.GetProdutoListMock();
            var Restaurantes = RestauranteMock.GetRestauranteListMock();
            var Users = UserMock.GetListUserMock();
            #endregion

            #region Seeds
            _context.Users.AddRange(Users);
            _context.Enderecos.AddRange(Enderecos);
            _context.Restaurantes.AddRange(Restaurantes);
            _context.Produtos.AddRange(Produtos);
            //_context.Pedidos.AddRange(Pedidos);
            //_context.PedidosProdutos.AddRange(PedidosProdutos);
            _context.SaveChanges();
            #endregion
        }
    }
}
