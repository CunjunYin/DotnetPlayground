using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using OpenIdConnectProvider.Data.Repositories;

namespace OpenIdConnectProvider.Core.Services;
public class TokenProvider
{
    public static string accessToken(string subject, string issuer, string audience, long expiresIn)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("some_secret_key_"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: new[] {
                new Claim("sub", subject),

            },
            expires: DateTime.Now.AddSeconds(expiresIn),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public static string IdToken(DatabaseContext db, string code, long expiresIn)
    {
        string GUID = db.AuthenticationCodes.Where(
            c => c.Code == code
        ).FirstOrDefault().UserId;

        if (GUID == null) {
            throw (new KeyNotFoundException("Code dosent exist"));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("some_secret_key_"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: "localhost",
            audience: "localhost",
            claims: new[] { new Claim("user", GUID) },
            expires: DateTime.Now.AddSeconds(expiresIn),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}