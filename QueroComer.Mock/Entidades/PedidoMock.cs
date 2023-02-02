using Microsoft.AspNetCore.Identity;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Enumerables;

namespace QueroComer.Mock.Entidades
{
    public class PedidoMock
    {
        public static Pedido GetPedidoMock()
        {
            return new Pedido
            {
                Id = Guid.Parse("aa6caffd-d52f-4db4-9b89-781a98d8ebbc"),
                UserId = UserMock.GetUserMock().Id,
                EnderecoId = EnderecoMock.GetEnderecoMock().Id,
                RestauranteId = RestauranteMock.GetRestauranteMock().Id,
                Preco = 12m,
                Data = DateTime.Now,
                Status = EStatusPedido.Concluido
            };
        }
        public static List<Pedido> GetPedidoListMock()
        {
            return new List<Pedido>
            {
                new Pedido
                {
                    Id = Guid.Parse("aa6caffd-d52f-4db4-9b89-781a98d8ebbc"),
                    UserId = UserMock.GetUserMock().Id,
                    EnderecoId = EnderecoMock.GetEnderecoMock().Id,
                    RestauranteId = RestauranteMock.GetRestauranteMock().Id,
                    Preco = 12m,
                    Data = DateTime.Now,
                    Status = EStatusPedido.Concluido
                },
                new Pedido
                {
                    Id = Guid.Parse("c11f5900-2255-45b8-9179-67911460fb07"),
                    UserId = UserMock.GetUserMock().Id,
                    EnderecoId = EnderecoMock.GetEnderecoMock().Id,
                    RestauranteId = RestauranteMock.GetRestauranteMock().Id,
                    Preco= 132m,
                    Data = DateTime.Now,
                    Status = EStatusPedido.Concluido
                },
                new Pedido
                {
                    Id = Guid.Parse("162a4f0f-b939-4ee8-aab4-8ea23d801e65"),
                    UserId = UserMock.GetUserMock().Id,
                    EnderecoId = EnderecoMock.GetEnderecoMock().Id,
                    RestauranteId = RestauranteMock.GetRestauranteMock().Id,
                    Preco= 64m,
                    Data = DateTime.Now,
                    Status = EStatusPedido.Concluido
                },
                new Pedido
                {
                    Id = Guid.Parse("069d0dd5-a764-4117-bdc3-87c1e473f250"),
                    UserId = UserMock.GetUserMock().Id,
                    EnderecoId = EnderecoMock.GetEnderecoMock().Id,
                    RestauranteId = RestauranteMock.GetRestauranteMock().Id,
                    Preco= 99m,
                    Data = DateTime.Now,
                    Status = EStatusPedido.Concluido
                }
            };
        }
    }
}
