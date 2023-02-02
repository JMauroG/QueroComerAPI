using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QueroComer.Entidades.Enumerables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QueroComer.Entidades.Entidades
{
    public class Restaurante
    {
        public Restaurante()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public ECategoriaRestaurante Categoria { get; set; }
        public string? Descricao { get; set; }

        [Column(TypeName = "decimal(18,1)")]
        public decimal Avaliacao { get; set; }
        [ForeignKey(nameof(Endereco))]
        public Guid EnderecoId { get; set; }
        [JsonIgnore]
        public virtual Endereco? Endereco { get; set; }
        public string? CNPJ { get; set; }
    }
}
