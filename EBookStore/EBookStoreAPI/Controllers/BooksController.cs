using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess;
using DataAccess.RepositoryImpl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookRepo repo = new BookRepo();
        private IMapper mapper;
        public BooksController(IMapper _mapper) => mapper = _mapper;
        // GET: api/<BooksController>
        [EnableQuery]
        [HttpGet]
        public ActionResult Get()
            => Ok(repo.GetBooks().Select(mapper.Map<Book, BookDTO>).ToList());

        // GET api/<BooksController>/5
        [EnableQuery]
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var book = repo.GetBookById(id);
            return book is null ? NotFound() : Ok(mapper.Map<BookDTO>(book));
        }
        
        [EnableQuery]
        [HttpGet]
        [Route("Update/{id}")]
        public ActionResult GetToUpdate(string id)
        {
            var book = repo.GetBookById(id);
            return book is null ? NotFound() : Ok(mapper.Map<CreateUpdateBookDTO>(book));
        }

        // POST api/<BooksController>
        [EnableQuery]
        [HttpPost]
        public IActionResult Post(CreateUpdateBookDTO bookDTO)
        {
            var id = repo.SaveBook(mapper.Map<Book>(bookDTO));
            return Ok(id);
        }

        // PUT api/<BooksController>/5
        [EnableQuery]
        [HttpPut("{id}")]
        public IActionResult Put(string id, CreateUpdateBookDTO bookDTO)
        {
            var bookToUpdate = repo.GetBookById(id);
            if (bookToUpdate is null) return NotFound();
            repo.UpdateBook(mapper.Map<Book>(bookDTO));
            return Ok();
        }

        // DELETE api/<BooksController>/5
        [EnableQuery]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var bookToDelete = repo.GetBookById(id);
            if (bookToDelete is null) return NotFound();
            repo.DeleteBook(bookToDelete);
            return Ok();
        }
    }
}
