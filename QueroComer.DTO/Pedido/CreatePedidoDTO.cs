using Microsoft.AspNetCore.Identity;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Enumerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueroComer.DTO.Pedido
{
    public class CreatePedidoDTO
    {
        public string UserId { get; set; }
        public Guid EnderecoId { get; set; }
        public Guid RestauranteId { get; set; }
        public decimal Preco { get; set; }
    }
}
