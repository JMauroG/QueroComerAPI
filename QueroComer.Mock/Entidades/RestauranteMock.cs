using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Enumerables;

namespace QueroComer.Mock.Entidades
{
    public class RestauranteMock
    {
        public static Restaurante GetRestauranteMock()
        {
            return new Restaurante
            {
                Id = Guid.Parse("3d5ed7ce-073e-484c-964f-b280f53b86ee"),
                Nome = "Akitanda",
                Categoria = ECategoriaRestaurante.Italiano,
                Descricao = "Comida Italiana muito boa",
                Avaliacao = 1.00m,
                EnderecoId = EnderecoMock.GetEnderecoRestauranteMock().Id,
                CNPJ = "48565940000154"
            };
        }

        public static List<Restaurante> GetRestauranteListMock()
        {
            return new List<Restaurante>
            {
                new Restaurante
                {
                    Id = Guid.Parse("3d5ed7ce-073e-484c-964f-b280f53b86ee"),
                    Nome = "Akitanda",
                    Categoria = ECategoriaRestaurante.Italiano,
                    Descricao = "Comida Italiana muito boa",
                    Avaliacao = 1.00m,
                    EnderecoId = EnderecoMock.GetEnderecoRestauranteMock().Id,
                    CNPJ = "48565940000154"
                },

                new Restaurante
                {
                    Id = Guid.Parse("9c022e4a-dcb6-4cbf-a2a0-9b5f40b9419b"),
                    Nome = "Akitanda Churrascaria",
                    Categoria = ECategoriaRestaurante.Churrascaria,
                    Descricao = "Comida Churrasco muito bom",
                    Avaliacao = 2.00m,
                    EnderecoId = EnderecoMock.GetEnderecoRestauranteMock().Id,
                    CNPJ = "76319923000172"
                },

                new Restaurante
                {
                    Id = Guid.Parse("720e6311-836b-498b-ab02-2c5c8916a82a"),
                    Nome = "Akitanda Arabe",
                    Categoria = ECategoriaRestaurante.Arabe,
                    Descricao = "Comida Arabe muito boa",
                    Avaliacao = 3.00m,
                    EnderecoId = EnderecoMock.GetEnderecoRestauranteMock().Id,
                    CNPJ = "88614175000130"
                },

                new Restaurante
                {
                    Id = Guid.Parse("c57a26af-aac9-4738-a61d-1925f9c6d5ad"),
                    Nome = "Akitanda Brasileira",
                    Categoria = ECategoriaRestaurante.Brasileira,
                    Descricao = "Comida Brasileira muito boa",
                    Avaliacao = 0.00m,
                    EnderecoId = EnderecoMock.GetEnderecoRestauranteMock().Id,
                    CNPJ = "10551287000100"
                }
            };
        }

        public static List<Restaurante> GetRestauranteListMock(ECategoriaRestaurante categoria)
        {
            return new List<Restaurante>
            {
                new Restaurante
                {
                    Id = Guid.Parse("3d5ed7ce-073e-484c-964f-b280f53b86ee"),
                    Nome = "Akitanda",
                    Categoria = categoria,
                    Descricao = "Comida Italiana muito boa",
                    Avaliacao = 1.00m,
                    EnderecoId = EnderecoMock.GetEnderecoRestauranteMock().Id,
                    CNPJ = "48565940000154"
                },

                new Restaurante
                {
                    Id = Guid.Parse("9c022e4a-dcb6-4cbf-a2a0-9b5f40b9419b"),
                    Nome = "Akitanda Churrascaria",
                    Categoria = categoria,
                    Descricao = "Comida Churrasco muito bom",
                    Avaliacao = 2.00m,
                    EnderecoId = EnderecoMock.GetEnderecoRestauranteMock().Id,
                    CNPJ = "76319923000172"
                },

                new Restaurante
                {
                    Id = Guid.Parse("720e6311-836b-498b-ab02-2c5c8916a82a"),
                    Nome = "Akitanda Arabe",
                    Categoria = categoria,
                    Descricao = "Comida Arabe muito boa",
                    Avaliacao = 3.00m,
                    EnderecoId = EnderecoMock.GetEnderecoRestauranteMock().Id,
                    CNPJ = "88614175000130"
                },

                new Restaurante
                {
                    Id = Guid.Parse("c57a26af-aac9-4738-a61d-1925f9c6d5ad"),
                    Nome = "Akitanda Brasileira",
                    Categoria = categoria,
                    Descricao = "Comida Brasileira muito boa",
                    Avaliacao = 0.00m,
                    EnderecoId = EnderecoMock.GetEnderecoRestauranteMock().Id,
                    CNPJ = "10551287000100"
                }
            };
        }
    }
}
