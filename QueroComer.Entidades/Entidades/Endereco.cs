using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QueroComer.Entidades.Entidades
{
    public class Endereco
    {
        public Endereco()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public string? Rua { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? CEP { get; set; }
        public string? UF { get; set; }
        public string? Cidade { get; set; }
        public string? Pais { get; set; }
        [ForeignKey(nameof(Usuario))]
        public string IdUsuario { get; set; }
        [JsonIgnore]
        public virtual IdentityUser? Usuario { get; set; }
    }
}
