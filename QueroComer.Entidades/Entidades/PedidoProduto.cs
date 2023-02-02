using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QueroComer.Entidades.Entidades
{
    public class PedidoProduto
    {
        public PedidoProduto()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(Produto))]
        public Guid ProdutoId { get; set; }
        [JsonIgnore]
        public virtual Produto Produto { get; set; }
        [ForeignKey(nameof(Pedido))]
        public Guid PedidoId { get; set; }
        [JsonIgnore]
        public virtual Pedido Pedido { get; set; }
        public int Quantidade { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
        public string Observacao { get; set; }
    }
}
