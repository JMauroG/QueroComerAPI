using QueroComer.Entidades.Enumerables;

namespace QueroComer.Entidades.Entidades
{
    public class RespostaLogin
    {
        public string? Email { get; set; }
        public string? Token { get; set; }
        public EStatusCode? StatusCode { get; set; }
        public bool? EmailConfirmado { get; set; }
        public string IdUsuario { get; set; }   
    }
}
