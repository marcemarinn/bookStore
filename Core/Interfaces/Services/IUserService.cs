using Core.Dtos;
using Core.Entities;

namespace Core.Interfaces.Services;

public interface IUserService
{
    Task<int> Register(UserDto request);
    Task<int> Login(UserDto request);
    Task<string> CreateToken(User user);

}
