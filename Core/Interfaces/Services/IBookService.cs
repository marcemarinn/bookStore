using Core.Request;

namespace Core.Interfaces.Services;

public interface IBookService
{
    public Task<int> Create(BookRequest request);
}
