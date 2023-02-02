using QueroComer.Entidades.Enumerables;

namespace QueroComer.Entidades.Entidades
{
    public class Resposta
    {
        public string? Mensagem { get; set; }
        public EStatusCode StatusCode { get; set; }
        public bool Sucesso { get; set; }
        public List<string>? ListaDeErros { get; set; }
    }
}
