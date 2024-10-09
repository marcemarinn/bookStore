using Core.Dtos;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace WebApi.Controllers;

public class AuthController : BaseApiController
{
    public static User user = new User();
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("register")]
    public ActionResult<User> Register(UserDto request)
    {
        string passwordHash
            = BCrypt.Net.BCrypt.HashPassword(request.PassWord);
        user.UserName = request.UserName;
        user.PassWordHash = passwordHash;
        return Ok(user);
    }
    [HttpPost("login")]
    public ActionResult<User> Login(UserDto request)
    {
        if (user.UserName != request.UserName)
           return BadRequest("User not found.");
        if (!BCrypt.Net.BCrypt.Verify(request.PassWord, user.PassWordHash))
            return BadRequest("bad passwords");

        string token = CreateToken(user);
            
        return Ok(token);
    }


    //crear un metodo que cree el token 
    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>()  {
            new Claim(ClaimTypes.Name,user.UserName)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value!));

        var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
            );
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;


    }


}
