using Core.Dtos;
using Core.Request;

namespace Core.Interfaces.Services;

public interface IBookService
{
    Task<int> Create(BookRequest request);
    Task<List<BookDTO>> Filter(FilterBookRequest request);
    Task<BookDTO> Update(BookDTO request);
    Task<BookDTO> Delete(int id);

}
