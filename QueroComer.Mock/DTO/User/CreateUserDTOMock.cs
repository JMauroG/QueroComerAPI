using Newtonsoft.Json;
using QueroComer.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QueroComer.Mock.DTO.User
{
    public class CreateUserDTOMock
    {
        public static CreateUserDTO GetCreateUserDTOMock()
        {
            return new CreateUserDTO
            {
                Email = "thainafernandes222@gmail.com",
                Password = "Senh4MuitoFod@",
                Nome = "Thaina2",
                Sobrenome = "Micaoski",
                Telefone = "21"
            };
        }

        public static string GetCreateUserDTOMockJson()
        {
            return JsonConvert.SerializeObject(CreateUserDTOMock.GetCreateUserDTOMock());
        }
    }
}
