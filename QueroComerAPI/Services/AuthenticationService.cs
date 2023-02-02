using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Interfaces;
using QueroComer.Entidades.Enumerables;

namespace QueroComer.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private IConfiguration _config;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<IdentityUser> _userManager;
        public AuthenticationService(IUserRepository userRepository,
                                     IConfiguration config,
                                     UserManager<IdentityUser> userManager)
        {
            _userRepository = userRepository;
            _config = config;
            _userManager = userManager;
        }

        /// <summary>
        ///     Realiza o login e gera a JWT
        /// </summary>
        /// <param name="login">Dto de login</param>
        /// <returns></returns>
        public async Task<RespostaLogin> LoginAsync(Login login)
        {
            try
            {
                var user = await _userRepository.RetornaUsuarioPorEmailAsync(login.Email);
                if (user == null || user.Id == "")
                    return new RespostaLogin
                    {
                        StatusCode = EStatusCode.NotFound
                    };

                var verifyPassword = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, login.Password);

                if (verifyPassword == PasswordVerificationResult.Success)
                {
                    var _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var _issuer = _config["Jwt:Issuer"];
                    var _audience = _config["Jwt:Audience"];

                    var signinCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256);

                    var tokenOptions = new JwtSecurityToken(
                        issuer: _issuer,
                        audience: _audience,
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: signinCredentials);

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                    return new RespostaLogin
                    {
                        Token = tokenString,
                        StatusCode = EStatusCode.Ok,
                        EmailConfirmado = user.EmailConfirmed,
                        Email = user.Email,
                        IdUsuario = user.Id
                    };
                }

                return new RespostaLogin
                {
                    Token = "",
                    StatusCode = EStatusCode.Unauthorized,
                    EmailConfirmado = false,
                    Email = ""
                };

            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
