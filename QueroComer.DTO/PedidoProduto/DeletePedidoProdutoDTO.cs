namespace QueroComer.DTO.PedidoProduto
{
    public class DeletePedidoProdutoDTO
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public Guid PedidoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public string Observacao { get; set; }
    }
}
