using Core.Dtos;
using Core.Interfaces.Services;
using Core.Request;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class BookController : BaseApiController
{
    private readonly IBookService _service;

    public BookController(IBookService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("/create")]
    public async Task<IActionResult> Create([FromBody] BookRequest request)
    {

       var books = await _service.Create(request);

        return Ok(books);
    }

    [HttpGet]
    [Route("/filter")]
    public async Task<IActionResult> Filter([FromQuery] FilterBookRequest request)
    {
        var books = await _service.Filter(request);
        return Ok(books);
    }

    [HttpPut]
    [Route("/update")]
    public async Task<IActionResult> Update(BookDTO body)
    {
        var book = await _service.Update(body);
        return Ok(book.Id);
    }


    [HttpDelete]
    [Route("/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _service.Delete(id);
        return Ok(book);
    }

}
