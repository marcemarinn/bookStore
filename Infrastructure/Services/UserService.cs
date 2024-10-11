using Core.Dtos;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task<string> CreateToken(User user)
    {
        throw new NotImplementedException();
    }

    public  Task<int> Login(UserDto request)
    {
        throw new NotImplementedException();

    }

    public async Task<int> Register(UserDto request)
    {
        int newUserId = await _repository.Login(request);

        return newUserId;
    }
}
