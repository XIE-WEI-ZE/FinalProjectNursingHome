// Helpers/OneTimeTokenHelper.cs
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace prjFinalProjectApi.Helpers
{
    public sealed class OneTimeTokenHelper
    {
        private readonly string _key, _issuer, _audience;

        public OneTimeTokenHelper(IConfiguration cfg)
        {
            _key = cfg["Jwt:Key"]!;
            _issuer = cfg["Jwt:Issuer"]!;
            _audience = cfg["Jwt:Audience"]!;
        }

        public string CreateToken(string purpose, int memberId, int minutes = 30)
        {
            var claims = new[]
            {
                new Claim("Purpose", purpose ?? "None"),
                new Claim("MemberId", memberId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(minutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public int? ValidateAndGetMemberId(string expectedPurpose, string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var param = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _issuer,
                    ValidAudience = _audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key)),
                    ClockSkew = TimeSpan.Zero
                };

                var principal = handler.ValidateToken(token, param, out _);
                var purpose = principal.FindFirstValue("Purpose");
                if (purpose != expectedPurpose) return null;

                var idVal = principal.FindFirstValue("MemberId");
                return int.TryParse(idVal, out var id) ? id : (int?)null;
            }
            catch
            {
                return null; // 無效 / 過期 / 簽章錯誤，一律視為無效
            }
        }

    }
}
