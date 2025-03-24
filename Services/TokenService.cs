using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DotNetEnv;
using Microsoft.IdentityModel.Tokens;

namespace BoletoApi.Services
{
    public class TokenService
    {
        public string GerarToken(string clientId)
        {
            var jwtKey = Encoding.ASCII.GetBytes(Env.GetString("JWT_KEY"));
            var jwtIssuer = Env.GetString("JWT_ISSUER");
            var jwtAudience = Env.GetString("JWT_AUDIENCE");
            var jwtExpireMinutes = Env.GetInt("JWT_EXPIRE_MINUTES");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("client_id", clientId) 
                }),
                Expires = DateTime.UtcNow.AddMinutes(jwtExpireMinutes),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(jwtKey),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Issuer = jwtIssuer,
                Audience = jwtAudience
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}