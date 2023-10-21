using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace eCommerce.Application.Services.Token;

public class TokenController
{
    private const string EmailAlias = "eml";
    private readonly double _tokenLifeTime;
    private readonly string _securityKey;

    public TokenController(double tokenLifeTime, string securityKey)
    {
        _tokenLifeTime = tokenLifeTime;
        _securityKey = securityKey;
    }
    
    public string CreateToken(string email)
    {
        var claims = new List<Claim>()
        {
            new Claim(EmailAlias, email)
        };
        
        //Objeto para criação do token
        var tokenHandler = new JwtSecurityTokenHandler();
        
        //Token descriptor
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_tokenLifeTime),
            SigningCredentials = new SigningCredentials(SymmetricKey(), SecurityAlgorithms.HmacSha256Signature)
        };

        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var token = tokenHandler.WriteToken(securityToken);

        return token;
    }
    
    //Token validation
    public void ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var validationParameters = new TokenValidationParameters()
        {
            RequireExpirationTime = true,
            IssuerSigningKey = SymmetricKey(),
            ClockSkew = new TimeSpan(0),
            ValidateIssuer = false,
            ValidateAudience = false
        };

        tokenHandler.ValidateToken(token, validationParameters, out _);
    }


    private SymmetricSecurityKey SymmetricKey()
    {
        var key = Convert.FromBase64String(_securityKey);
        return new SymmetricSecurityKey(key);
    }
}