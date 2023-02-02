using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueroComer.Mock.Entidades
{
    public class UserMock
    {
        public static IdentityUser GetUserMock()
        {
            return new IdentityUser
            {
                Email = "thainamicaoski2000@gmail.com",
                UserName = "Thaina",
                Id = "09a80dee-f695-481b-ac43-ba6538f89c8e",
                NormalizedUserName = "THAINA",
                NormalizedEmail = "THAINAMICAOSKI2000@GMAIL.COM",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAIAAYagAAAAEOwYSVxos0byXZLZDoiGonXjtuQEQk5tqwG5PLYRzqsOV9+OgEB4EJs+d91HDQ72hQ==",
                SecurityStamp = "RG4GCUWXILWWSGCZT7WZUN4K6HUFWR6X",
                ConcurrencyStamp = "0fd584e1-5e06-4838-a9ec-ad07da62358c",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0,
            };
        }
        public static List<IdentityUser> GetListUserMock()
        {
            return new List<IdentityUser>()
            {
                new IdentityUser
                {
                    Email = "thainamicaoski2000@gmail.com",
                    UserName = "Thaina",
                    Id = "09a80dee-f695-481b-ac43-ba6538f89c8e",
                    NormalizedUserName = "THAINA",
                    NormalizedEmail = "THAINAMICAOSKI2000@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAIAAYagAAAAEOwYSVxos0byXZLZDoiGonXjtuQEQk5tqwG5PLYRzqsOV9+OgEB4EJs+d91HDQ72hQ==",
                    SecurityStamp = "RG4GCUWXILWWSGCZT7WZUN4K6HUFWR6X",
                    ConcurrencyStamp = "0fd584e1-5e06-4838-a9ec-ad07da62358c",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                },
                new IdentityUser
                {
                    Email = "ncjuninho@hotmail.com",
                    UserName = "Nilton2",
                    Id = "e85380fc-764a-4605-ad12-e9685ddadacc",
                    NormalizedUserName = "NILTON2",
                    NormalizedEmail = "NCJUNINHO@HOTMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAIAAYagAAAAEKAzJ/gH923/+1LZaMX3xL58zUELrTRtNNtb9yF/7CLCw5a/i1xplCdl9IFN3X7EjQ==",
                    SecurityStamp = "SMSIOIVZAEKCQ6VHZEXYWSLF3PMLP4VI",
                    ConcurrencyStamp = "ceee7518-4b06-4038-90f7-c2411f13eca6",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                },
                new IdentityUser
                {
                    Email = "juca.8@hotmail.com",
                    UserName = "JoseMauro",
                    Id = "9e124f84-cd46-4ac1-8ad1-426ebeb57f88",
                    NormalizedUserName = "JOSEMAURO",
                    NormalizedEmail = "JUCA.8@HOTMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAIAAYagAAAAEFt1BHUGHSNvqnfKZVKhk6XzpQavP2DRnzynKsD9YqpXqpeUHLs7ZTpEeArs0dolww==",
                    SecurityStamp = "B2RRO6R6SYEW3VJA5SDULNBTQL643N56",
                    ConcurrencyStamp = "124d0dbe-5529-4f87-8686-a8b3eb108ab2",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                },
                new IdentityUser
                {
                    Email = "restaurante@gmail.com",
                    UserName = "Restaurante",
                    Id = "a4cfd26e-a2e1-429a-92e7-8f391ee07722",
                    NormalizedUserName = "RESTAURANTE",
                    NormalizedEmail = "RESTAURANTE@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAIAAYagAAAAEOwYSVxos0byXZLZDoiGonXjtuQEQk5tqwG5PLYRzqsOV9+OgEB4EJs+d91HDQ72hQ==",
                    SecurityStamp = "RG4GCUWXILWWSGCZT7WZUN4K6HUFWR6X",
                    ConcurrencyStamp = "0fd584e1-5e06-4838-a9ec-ad07da62358c",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                }
            };
        }
        public static IdentityUser GetUserRestauranteMock()
        {
            return new IdentityUser
            {
                Email = "restaurante@gmail.com",
                UserName = "Restaurante",
                Id = "a4cfd26e-a2e1-429a-92e7-8f391ee07722",
                NormalizedUserName = "RESTAURANTE",
                NormalizedEmail = "RESTAURANTE@GMAIL.COM",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAIAAYagAAAAEOwYSVxos0byXZLZDoiGonXjtuQEQk5tqwG5PLYRzqsOV9+OgEB4EJs+d91HDQ72hQ==",
                SecurityStamp = "RG4GCUWXILWWSGCZT7WZUN4K6HUFWR6X",
                ConcurrencyStamp = "0fd584e1-5e06-4838-a9ec-ad07da62358c",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0,
            };
        }
    }
}
