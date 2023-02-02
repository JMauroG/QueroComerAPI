using QueroComer.DTO.Endereco;
using QueroComer.Entidades.Enumerables;

namespace QueroComer.DTO.Restaurante
{
    public class CreateRestauranteDTO
    {
        public string Nome { get; set; }
        public ECategoriaRestaurante Categoria { get; set; }
        public string Descricao { get; set; }
        public Guid EnderecoId { get; set; }
        public string CNPJ { get; set; }
    }
}
