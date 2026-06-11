using ASP.NET10_Docker_K8s.Model;
using ASP.NET10_Docker_K8s.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET10_Docker_K8s.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookServices _bookServices;

        public BookController(IBookServices bookServices, ILogger<BookController> logger)
        {
            _bookServices = bookServices;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            _logger.LogInformation("Find all Book");
            return Ok(_bookServices.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(long id)
        {
            _logger.LogInformation("Find Book by id {id}", id);

            if(id <= 0) 
                return BadRequest("Invalid request!");

            var book = _bookServices.FindById(id);
            if(book == null) 
                return NotFound("Book not found!");

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            _logger.LogInformation("Creating new Book: {title}", book.Title);

            var createdPerson = _bookServices.Create(book);
            if(createdPerson == null) 
                return BadRequest("Invalid request!");

            return Ok(createdPerson);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Book book)
        {
            _logger.LogInformation("Updating Book: {id}", book.Id);

            var updatePerson = _bookServices.Update(book);
            if(updatePerson == null) return NotFound("Book not found!");

            return Ok(updatePerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting Book: {id}", id);

            var bookFound = _bookServices.FindById(id);
            if(bookFound == null) return NotFound("Book not found!");

            _bookServices.Delete(id);
            return NoContent();
        }
    }
}
