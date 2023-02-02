using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Enumerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueroComer.Mock.Entidades
{
    public class ProdutoMock
    {
        public static Produto GetProdutoMock()
        {
            return new Produto
            {
                Id = Guid.Parse("aa61dc7e-ac3a-4a73-9591-c69a9e735167"),
                RestauranteId = RestauranteMock.GetRestauranteMock().Id,
                Nome = "Ravioli de carne ao molho de tomate",
                Descricao = " Pequenos pastéis recheados com carne cozidos no molho de tomade",
                Categoria = ECategoriaProduto.Refeicao,
                Preco = 30
            };
        }

        public static List<Produto> GetProdutoListMock(Restaurante restaurante)
        {
            return new List<Produto>
            {
                new Produto
                {
                    Id = Guid.Parse("aa61dc7e-ac3a-4a73-9591-c69a9e735167"),
                    RestauranteId = restaurante.Id,
                    Nome = "Ravioli de carne ao molho de tomate",
                    Descricao = " Pequenos pastéis recheados com carne ao de molho de tomade",
                    Categoria = ECategoriaProduto.Refeicao,
                    Preco = 30
                },

                new Produto
                {
                    Id = Guid.Parse("cef81f38-266e-46db-a090-7c5e85868c6b"),
                    RestauranteId = restaurante.Id,
                    Nome = "Ravioli de carne ao molho branco",
                    Descricao = " Pequenos pastéis cozidos recheados com carne ao de molho de branco",
                    Categoria = ECategoriaProduto.Refeicao,
                    Preco = 30
                },

                new Produto
                {
                    Id = Guid.Parse("cd237fb4-4fdf-4136-b2f7-2e279947a717"),
                    RestauranteId = restaurante.Id,
                    Nome = "Ravioli frito",
                    Descricao = "Raviolis fritos nas opções de queijo, peixe e carne acompanhados com molho de queijo e ervas",
                    Categoria = ECategoriaProduto.Refeicao,
                    Preco = 30
                },
            };
        }

        public static List<Produto> GetProdutoListMock()
        {
            return new List<Produto>
            {
                new Produto
                {
                    Id = Guid.Parse("aa61dc7e-ac3a-4a73-9591-c69a9e735167"),
                    RestauranteId = RestauranteMock.GetRestauranteMock().Id,
                    Nome = "Ravioli de carne ao molho de tomate",
                    Descricao = " Pequenos pastéis recheados com carne ao de molho de tomade",
                    Categoria = ECategoriaProduto.Refeicao,
                    Preco = 30
                },

                new Produto
                {
                    Id = Guid.Parse("cef81f38-266e-46db-a090-7c5e85868c6b"),
                    RestauranteId = RestauranteMock.GetRestauranteMock().Id,
                    Nome = "Ravioli de carne ao molho branco",
                    Descricao = " Pequenos pastéis cozidos recheados com carne ao de molho de branco",
                    Categoria = ECategoriaProduto.Refeicao,
                    Preco = 30
                },

                new Produto
                {
                    Id = Guid.Parse("cd237fb4-4fdf-4136-b2f7-2e279947a717"),
                    RestauranteId = RestauranteMock.GetRestauranteMock().Id,
                    Nome = "Ravioli frito",
                    Descricao = "Raviolis fritos nas opções de queijo, peixe e carne acompanhados com molho de queijo e ervas",
                    Categoria = ECategoriaProduto.Refeicao,
                    Preco = 30
                },
            };
        }
    }
}
