using DemoCleanArchitecture.Domain.Enums;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoCleanArchitecture.Presentation.WebAPI.Tools
{
    public sealed class TokenTool
    {
        private readonly IConfiguration _config;
        public TokenTool(IConfiguration configuration)
        {
            _config = configuration;
        }

        public class Data
        {
            public required long MemberId { get; set; }
            public required MemberRoleEnum Role { get; set; }
        }

        public string Generate(Data data)
        {
            // Claims - Objet avec les données pour le token
            Claim[] claims = [
                new Claim("THE Response", "42"),
                new Claim(ClaimTypes.NameIdentifier, data.MemberId.ToString()),
                new Claim(ClaimTypes.Role, data.Role.ToString())
            ];

            // Clefs du token
            byte[] key = Encoding.UTF8.GetBytes(_config["Token:Secret"]!);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            // Création du token
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config["Token:Issuer"],
                audience: _config["Token:Audience"],
                expires: DateTime.Now.AddMinutes(_config.GetValue<double>("Token:ExpiresMinute")),
                claims: claims,
                signingCredentials: signingCredentials
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
