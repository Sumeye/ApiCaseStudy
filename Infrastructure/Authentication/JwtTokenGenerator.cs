using Application.Common.Interfaces.Authentication;
using Application.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;

        public JwtTokenGenerator(IOptions<JwtSettings> jwtOptions)
        {
            _jwtSettings = jwtOptions.Value;
        }


        public TokenDto GenerateToken(UserApp user)
        {
            var refreshTokenExpration = DateTime.Now.AddMinutes(_jwtSettings.RefreshTokenExpiration);
            var accesTokenExpiration = DateTime.Now.AddMinutes(_jwtSettings.ExpiryMinutes);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature);
            var claims = new[]
            {
               new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
               new Claim(JwtRegisteredClaimNames.GivenName,user.Name),
               new Claim(JwtRegisteredClaimNames.FamilyName,user.SurName),
               new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: accesTokenExpiration,
                claims: claims,
                signingCredentials: signingCredentials
                );
            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(securityToken);
            var tokenDto = new TokenDto
            {
                AccessToken = token,
                RefreshToken = CreateRefreshToken(),
            };
            return tokenDto;
        }

        private string CreateRefreshToken()
        {
            var numberByte = new Byte[32];
            using var rnd = RandomNumberGenerator.Create();
            rnd.GetBytes(numberByte);
            return Convert.ToBase64String(numberByte);
        }
    }
}

