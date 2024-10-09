using Core.Dtos;
using Core.Request;

namespace Core.Interfaces.Repositories;

public interface IBookRepository
{
    Task <int> Create(BookRequest request);
    Task <List<BookDTO>> Filter(FilterBookRequest request);
    Task<BookDTO> Update(BookDTO request);
    Task<BookDTO> Delete(int id);


}
