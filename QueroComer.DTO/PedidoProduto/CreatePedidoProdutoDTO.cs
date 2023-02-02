using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueroComer.DTO.PedidoProduto
{
    public class CreatePedidoProdutoDTO
    {
        public Guid ProdutoId { get; set; }
        public Guid PedidoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public string Observacao { get; set; }
    }
}
