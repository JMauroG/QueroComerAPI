using QueroComer.Entidades.Enumerables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QueroComer.Entidades.Entidades
{
    public class Pedido
    {
        public Pedido()
        {
            Id = Guid.NewGuid();
            Status = EStatusPedido.Aberto;
            Data = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("Endereco")]
        public Guid EnderecoId { get; set; }
        [JsonIgnore]
        public virtual Endereco Endereco { get; set; }
        [ForeignKey(nameof(Restaurante))]
        public Guid RestauranteId { get; set; }
        [JsonIgnore]
        public virtual Restaurante Restaurante { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
        public DateTime Data { get; set; }
        public EStatusPedido Status { get; set; }

    }
}
