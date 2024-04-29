namespace OneStreamAPI2.Common
{
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public static class JwtToken
    {        
        public static string GetToken(string secretKey)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, ConfigHelper.GetSectionValue("Security","UserName")),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
            var token = new JwtSecurityToken(
                issuer: ConfigHelper.GetSectionValue("Security","Issuer"),
                audience: ConfigHelper.GetSectionValue("Security","Audience"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
