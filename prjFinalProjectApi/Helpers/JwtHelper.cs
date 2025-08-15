using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace prjFinalProjectApi.Helpers
{
    public class JwtHelper
    {
        public static string GenerateToken(
            int memberId,
            string account,
            string email,
            string secretKey,
            string issuer,
            string audience,
            int expirMinutes = 60)
        {
            if (string.IsNullOrEmpty(account))
                throw new ArgumentNullException(nameof(account));
            if (string.IsNullOrEmpty(secretKey))
                throw new ArgumentNullException(nameof(secretKey));
            if (secretKey.Length < 32)
                throw new ArgumentException("JWT Key 長度不足，必須至少 32 字元。", nameof(secretKey));
            if (string.IsNullOrEmpty(issuer))
                throw new ArgumentNullException(nameof(issuer));
            if (string.IsNullOrEmpty(audience))
                throw new ArgumentNullException(nameof(audience));

            try
            {
                var claims = new[]
                {
                    new Claim("MemberId", memberId.ToString()), // 加入會員 ID
                    new Claim(ClaimTypes.Name, account),       // 帳號
                    new Claim(ClaimTypes.Email, email),        // Email
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, memberId.ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(expirMinutes),
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"JWT 產生失敗: {ex.Message}", ex);
            }
        }
    }
}
