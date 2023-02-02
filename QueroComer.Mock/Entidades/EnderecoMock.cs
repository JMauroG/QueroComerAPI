using QueroComer.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueroComer.Mock.Entidades
{
    public class EnderecoMock
    {
        public static Endereco GetEnderecoMock()
        {
            return new Endereco
            {
                Id = Guid.Parse("7b2a696a-71c8-43c8-a861-4e92481ff03e"),
                Rua = "Rua Jose do Patrocinio",
                Numero = "290",
                Complemento = "apto 320",
                Bairro = "Centro",
                CEP = "26520320",
                UF = "RJ",
                Cidade = "Nilopolis",
                Pais = "Brasil",
                IdUsuario = UserMock.GetUserMock().Id
            };
        }
        public static List<Endereco> GetListEnderecoMock()
        {
            return new List<Endereco>
            {
                new Endereco
                {
                    Id = Guid.Parse("b8c10a11-32fe-41fc-b8a6-c0966ed85415"),
                    Rua = "Rua Jose do Patrocinio",
                    Numero = "290",
                    Complemento = "apto 320",
                    Bairro = "Centro",
                    CEP = "26520320",
                    UF = "RJ",
                    Cidade = "Nilopolis",
                    Pais = "Brasil",
                    IdUsuario = UserMock.GetUserMock().Id
                },
                new Endereco
                {
                    Id = Guid.Parse("90e52aef-ebd0-470d-a1f2-0646658effde"),
                    Rua = "Rua Jose do Patrocinio",
                    Numero = "365",
                    Complemento = "apto 305",
                    Bairro = "Centro",
                    CEP = "26520320",
                    UF = "RJ",
                    Cidade = "Nilopolis",
                    Pais = "Brasil",
                    IdUsuario = UserMock.GetUserMock().Id
                },
                new Endereco
                {
                    Id = new Guid("8309174a-54e6-44af-9684-483708bdf694"),
                    Rua = "Rua Jose do Patrocinio",
                    Numero = "505",
                    Complemento = "apto 311",
                    Bairro = "Centro",
                    CEP = "26520320",
                    UF = "RJ",
                    Cidade = "Nilopolis",
                    Pais = "Brasil",
                    IdUsuario = UserMock.GetUserMock().Id
                },
                new Endereco
                {
                    Id = Guid.Parse("90b6548b-4cd0-4e7b-b10a-9c33bd958142"),
                    Rua = "Rua Dias da Cruz",
                    Numero = "01",
                    Complemento = "Loja 1",
                    Bairro = "Meier",
                    CEP = "20720010",
                    UF = "RJ",
                    Cidade = "Rio De Janeiro",
                    Pais = "Brasil",
                    IdUsuario = UserMock.GetUserRestauranteMock().Id
                }
            };
        }
        public static Endereco GetEnderecoRestauranteMock()
        {
            return new Endereco
            {
                Id = Guid.Parse("90b6548b-4cd0-4e7b-b10a-9c33bd958142"),
                Rua = "Rua Dias da Cruz",
                Numero = "01",
                Complemento = "Loja 1",
                Bairro = "Meier",
                CEP = "20720010",
                UF = "RJ",
                Cidade = "Rio De Janeiro",
                Pais = "Brasil",
                IdUsuario = UserMock.GetUserRestauranteMock().Id
            };
        }
    }
}
