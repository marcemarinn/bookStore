using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Request;
using Infrastructure.Context;
using Mapster;

namespace Infrastructure.Repositories;

public class BookRepository : IBookRepository
{

    private readonly DataBaseContext _context;

    public BookRepository(DataBaseContext context)
    {
        _context = context;
    }
    public async Task <int> create(BookRequest request)
    {

        var newBook = request.Adapt<Book>(); // Mapea BookRequest a Book
        _context.Books.Add(newBook);
        await _context.SaveChangesAsync();
        return newBook.Id;

    }
}
