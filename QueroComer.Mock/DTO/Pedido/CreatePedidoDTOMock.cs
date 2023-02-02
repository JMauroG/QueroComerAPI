using QueroComer.DTO.Pedido;
using QueroComer.Mock.Entidades;

namespace QueroComer.Mock.DTO.Pedido
{
    public class CreatePedidoDTOMock
    {
        public static CreatePedidoDTO GetCreatePedidoDTO()
        {
            return new CreatePedidoDTO 
            { 
                UserId = UserMock.GetUserMock().Id,
                EnderecoId = EnderecoMock.GetEnderecoMock().Id,
                RestauranteId = RestauranteMock.GetRestauranteMock().Id,
                Preco = 12
            };
        }
    }
}
