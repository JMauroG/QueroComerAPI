using QueroComer.DTO.Endereco;

namespace QueroComer.Mock.DTO.Endereco
{
    public class CreateEnderecoDTOMock
    {
        public static CreateEnderecoDTO GetCreateEnderecoDTOMock()
        {
            return new CreateEnderecoDTO
            {
                Rua = "Rua Jose do Patrocinio",
                Numero = "290",
                Complemento = "apto 320",
                Bairro = "Centro",
                CEP = "26520320",
                UF = "RJ",
                Cidade = "Nilopolis",
                Pais = "Brasil",
            };
        }
    }
}
