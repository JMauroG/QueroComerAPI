using QueroComer.DTO.Pedido;
using QueroComer.Entidades.Enumerables;
using QueroComer.Mock.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace QueroComer.Mock.DTO.Pedido
{
    public class UpdatePedidoDTOMock
    {
        public static UpdatePedidoDTO GetUpdatePedidoDTO()
        {
            return new UpdatePedidoDTO
            {
                Id = PedidoMock.GetPedidoMock().Id,
                Status = EStatusPedido.ACaminho
            };
        }
    }
}
