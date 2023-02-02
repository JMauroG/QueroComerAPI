using QueroComer.Entidades.Enumerables;

namespace QueroComer.DTO.Produto
{
    public class CreateProdutoDTO
    {
        public Guid RestauranteId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public ECategoriaProduto Categoria { get; set; }
        public decimal Preco { get; set; }
    }
}
