using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueroComer.DTO.PedidoProduto
{
    public class UpdatePedidoProdutoDTO
    {
        public Guid Id { get; set; }
        public int Quantidade { get; set; }
    }
}
