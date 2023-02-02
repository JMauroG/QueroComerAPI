using QueroComer.Entidades.Enumerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueroComer.DTO.Pedido
{
    public class ReadPedidoDTO
    {
        public string? UserId { get; set; }
        public Guid EnderecoId { get; set; }
        public decimal Preco { get; set; }
        public DateTime Data { get; set; }
        public Guid Id { get; set; }
        public EStatusPedido Status { get; set; }
    }
}
