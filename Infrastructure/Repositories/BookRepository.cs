using Core.Dtos;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Request;
using Infrastructure.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Infrastructure.Repositories;

public class BookRepository : IBookRepository
{

    private readonly DataBaseContext _context;

    public BookRepository(DataBaseContext context)
    {
        _context = context;
    }
    public async Task <int> Create(BookRequest request)
    {

        var newBook = request.Adapt<Book>(); // Mapea BookRequest a Book
        _context.Books.Add(newBook);
        await _context.SaveChangesAsync();
        return newBook.Id;
    }

    public async Task<BookDTO> Delete(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return null;
        }

        book.isActive = false;

        await _context.SaveChangesAsync();

        var bookDTO = book.Adapt<BookDTO>();

        return bookDTO;
    }
  

    public async Task<List<BookDTO>> Filter(FilterBookRequest request)
    {

        // Obtiene la consulta inicial de los libros, aplicando el filtro por isActive
        var query = _context.Books.Where(b => b.isActive == request.IsActive);

        // Verifica si las fechas son válidas (no MinValue)
        if (request.From is not null && request.From.Value != DateTime.MinValue)
        {
            query = query.Where(b => b.PublishDate >= request.From.Value);
        }

        if (request.To.HasValue && request.To.Value != DateTime.MinValue)
        {
            query = query.Where(b => b.PublishDate <= request.To.Value);
        }


        // Aplica el filtro por nombre si se proporciona (ignora mayúsculas y minúsculas)
        if (!string.IsNullOrEmpty(request.Name))
        {
            query = query.Where(b => EF.Functions.ILike(b.Title, $"%{request.Name}%"));
        }

        // Proyecta los resultados a BookDTO
        return await query
            .Select(b => new BookDTO
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                isActive = b.isActive,
                PublishDate = b.PublishDate
            })
            .ToListAsync();
    }

  

    public Task<List<BookDTO>> ListView(DateTime startDate, DateTime endDate, string name, bool isActive)
    {
        throw new NotImplementedException();
    }

    public async Task<BookDTO> Update(BookDTO request)
    {

        //var book = _context.Books.FirstOrDefault(b => b.Id == id);// Siempre realiza una consulta a la base de datos, incluso si la entidad está en el contexto
        var book = await _context.Books.FindAsync(request.Id); //si se encuentra en la memoria caché del contexto, FindAsync devolverá la entidad del contexto sin hacer una nueva consulta a la base de datos.
        if (book == null)
        {
            return null;
        }

        // Actualizar el libro utilizando el mapper
        request.Adapt(book); // Mapea las propiedades de BookRequest al objeto Book existente

        _context.Books.Update(book);
        _context.SaveChanges();
        return request;//necesito el id del libro para actualizar 
    }

   
}
