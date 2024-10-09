using Core.Dtos;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Request;

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
        int newBookId = await _repository.Create(request);

        return newBookId;
    }

    public Task<BookDTO> Delete(int id)
    {
       return _repository.Delete(id);
    }

    public async Task<List<BookDTO>> Filter(FilterBookRequest request)
    {
        return await _repository.Filter(request);
    }


    public async Task<BookDTO> Update(BookDTO request)
    {
        return await _repository.Update(request);
    }

}


