using QueroComer.Entidades.Enumerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueroComer.DTO.Pedido
{
    public class UpdatePedidoDTO
    {
        public Guid Id { get; set; }
        public EStatusPedido Status { get; set; }
    }
}
