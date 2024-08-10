using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Request;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Create(BookRequest request)
    {
        int newBookId = await _repository.create(request);

        return newBookId;
    }
}
