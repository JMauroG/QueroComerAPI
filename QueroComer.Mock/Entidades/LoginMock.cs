using QueroComer.Entidades.Entidades;

namespace QueroComer.Mock.Entidades
{
    public class LoginMock
    {
        public static Login GetLoginDTOMock()
        {
            return new Login
            {
                Email = "thainamicaoski2000@gmail.com",
                Password = "Senh4MuitoFod@",
            };
        }
    }
}
