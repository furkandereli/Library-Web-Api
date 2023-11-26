using LibraryWebApi.Dtos.Requests;
using LibraryWebApi.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] CreateBookRequestDto requestDto)
        {
            var response = _bookService.Add(requestDto);
            
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
                return Created("/", response);

            return BadRequest(response);
        }

        [HttpGet("GetBookById")]
        public IActionResult GetBookById([FromQuery] int id)
        {
            var response = _bookService.GetById(id);
            
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(response);
            
            if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return NotFound(response);

            return BadRequest();
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var response = _bookService.GetList();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpDelete("DeleteBook")]
        public IActionResult Delete([FromQuery] int id)
        {
            var response = _bookService.Delete(id);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPut("UpdateBook")]
        public IActionResult Update([FromBody] UpdateBookRequestDto requestDto)
        {
            var response = _bookService.Update(requestDto);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(response);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return NotFound(response);

            return BadRequest(response);
        }
    }
}
