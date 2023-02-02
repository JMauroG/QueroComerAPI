using QueroComer.DTO.Restaurante;
using QueroComer.Entidades.Enumerables;
using QueroComer.Mock.DTO.Endereco;
using QueroComer.Mock.Entidades;

namespace QueroComer.Mock.DTO.Restaurante
{
    public class CreateRestauranteDTOMock
    {
        public static CreateRestauranteDTO GetCreateRestauranteDTOMock()
        {
            return new CreateRestauranteDTO
            {
                Nome = "Akitanda",
                Categoria = ECategoriaRestaurante.Italiano,
                Descricao = "Comida Italiana muito boa",
                EnderecoId = EnderecoMock.GetEnderecoMock().Id,
                CNPJ = "48565940000154"
            };
        }
    }
}
