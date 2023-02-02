using QueroComer.DTO.PedidoProduto;
using QueroComer.Mock.Entidades;

namespace QueroComer.Mock.DTO.PedidoProduto
{
    public class CreatePedidoProdutoDTOMock
    {
        public static CreatePedidoProdutoDTO GetCreatePedidoProdutoDTO()
        {
            return new CreatePedidoProdutoDTO
            {
                PedidoId = PedidoMock.GetPedidoMock().Id,
                ProdutoId = ProdutoMock.GetProdutoMock().Id,
                Quantidade = 1,
                Preco = 13,
                Observacao = ""
            };
        }
    }
}
