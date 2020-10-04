using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using e_descarte_api.Models;
using Microsoft.IdentityModel.Tokens;

namespace e_descarte_api.jwt.Services
{
    public static class TokenServices
    {
        public static string GenerateToken(Usuario usuario)
        {
            var chave = "aaa123bbb456ccc789ddd147eee852fff963jjj159hhh753";
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(chave);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,usuario.nome.ToString())
                    
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);
            return token;
        }
    }
}