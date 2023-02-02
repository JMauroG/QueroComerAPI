using QueroComer.DTO.Produto;
using QueroComer.Entidades.Enumerables;
using QueroComer.Mock.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueroComer.Mock.DTO.Produto
{
    public class CreateProdutoDTOMock
    {
        public static CreateProdutoDTO GetCreateProdutoDTO()
        {
            return new CreateProdutoDTO
            {
                RestauranteId = RestauranteMock.GetRestauranteMock().Id,
                Nome = "Ravioli de carne ao molho de tomate",
                Descricao = " Pequenos pastéis recheados com carne cozidos no molho de tomade",
                Categoria = ECategoriaProduto.Refeicao,
                Preco = 30
            };
        }
    }
}
