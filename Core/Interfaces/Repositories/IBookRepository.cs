using Core.Request;

namespace Core.Interfaces.Repositories;

public interface IBookRepository
{
    Task <int> create(BookRequest request);
}
