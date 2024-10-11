using BCrypt.Net;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Context;
using Mapster;
using System.Net;


namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataBaseContext _context;

    public UserRepository(DataBaseContext context)
    {
        _context = context;
    }
    public async Task<int> Register(UserDto request)
    {
        var newUser = request.Adapt<User>();
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.PassWord);
        newUser.UserName = request.UserName;
        newUser.PassWordHash = passwordHash;
        _context.Users.Add(newUser);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return (int)HttpStatusCode.BadRequest;
        }
        return newUser.Id;
    }

    public  Task<int> Login(UserDto request)
    {
        throw new NotImplementedException();

    }

    public Task<string> CreateToken(User user)
    {
    throw new NotImplementedException();
    }

  

   
}
