using QueroComer.Entidades.Entidades;

namespace QueroComer.Mock.Entidades
{
    public class PedidoProdutoMock
    {
        public static PedidoProduto GetPedidoProdutoMock()
        {
            return new PedidoProduto
            {
                Id = Guid.Parse("6f367a35-e37e-475c-aeec-f37bb480956e"),
                ProdutoId = ProdutoMock.GetProdutoMock().Id,
                PedidoId = PedidoMock.GetPedidoMock().Id,
                Quantidade = 1,
                Preco = 13,
                Observacao = ""
            };
        }

        public static List<PedidoProduto> GetPedidoProdutoListMock(Pedido pedido)
        {
            return new List<PedidoProduto> 
            { 
                new PedidoProduto
                {
                    Id = Guid.Parse("6f367a35-e37e-475c-aeec-f37bb480956e"),
                    PedidoId = pedido.Id,
                    ProdutoId = ProdutoMock.GetProdutoMock().Id,
                    Quantidade = 1,
                    Preco = 13,
                    Observacao = ""
                },
                
                new PedidoProduto
                {
                    Id = Guid.Parse("59c241c3-7a39-42b2-98c9-bdc2a3fe2357"),
                    PedidoId = pedido.Id,
                    ProdutoId = ProdutoMock.GetProdutoMock().Id,
                    Quantidade = 1,
                    Preco = 13,
                    Observacao = ""
                },
                
                new PedidoProduto
                {
                    Id = Guid.Parse("6017bb8b-c2f9-4fe7-8321-4c9cc7529497"),
                    PedidoId = pedido.Id,
                    ProdutoId = ProdutoMock.GetProdutoMock().Id,
                    Quantidade = 1,
                    Preco = 13,
                    Observacao = ""
                }
            };
        }
    }
}
