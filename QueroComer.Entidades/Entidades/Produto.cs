using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QueroComer.Entidades.Enumerables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QueroComer.Entidades.Entidades
{
    public class Produto
    {
        public Produto()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(Restaurante))]
        public Guid RestauranteId { get; set; }
        [JsonIgnore]
        public virtual Restaurante Restaurante { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ECategoriaProduto Categoria { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
    }
}
