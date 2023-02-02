using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QueroComer.IntegrationTest
{
    public class BaseTest
    {
        protected readonly string _token;
        public BaseTest()
        {
            var _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("chaveSuperSecretaDoJwt"));
            var _issuer = "AlgumIssuer";
            var _audience = "AlgumaAudience";

            var signinCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(900),
                signingCredentials: signinCredentials);

            _token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}
