using QueroComer.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueroComer.Entidades.Interfaces
{
    public interface IProdutoRepository
    {
        Task CadastrarProdutoAsync(Produto produto);
        Task<Produto> RecuperarProdutoPorIdAsync(Guid IdProduto);
        Task<List<Produto>> RecuperarProdutosPorRestauranteAsync(Guid IdRestaurante);
        IEnumerable<Produto> GetEnumerable();
    }
}
