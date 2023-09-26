using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess;
using DataAccess.RepositoryImpl;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksAuthorsController : ControllerBase
    {
        private IBookAuthorRepo repo = new BookAuthorRepo();
        private IMapper mapper;
        public BooksAuthorsController(IMapper _mapper) => mapper = _mapper;

        // GET: api/<BooksAuthorsController>
        [HttpGet]
        public ActionResult Get() => Ok(repo.GetBooksAuthors().Select(mapper.Map<BookAuthor, BookAuthorDTO>).ToList());

        // GET: api/<BooksAuthorsController>
        [HttpGet]
        [Route("Books")]
        public ActionResult Get(string authorId) => Ok(repo.GetBooksByAuthorId(authorId).Select(mapper.Map<BookAuthor, BookAuthorDTO>).ToList());

        // GET: api/<BooksAuthorsController>
        [HttpGet]
        [Route("Authors")]
        public ActionResult Get(string bookId, string? type) => Ok(repo.GetAuthorsByBookId(bookId).Select(mapper.Map<BookAuthor, BookAuthorDTO>).ToList());

        // GET api/<BooksAuthorsController>/5
        [HttpGet("{book}/{author}")]
        public ActionResult GetToUpdate(string book, string author)
        {
            var bookAuthor = repo.GetBookAuthorById(book, author);
            return bookAuthor is null ? NotFound() : Ok(mapper.Map<CreateUpdateBookAuthorDTO>(bookAuthor));
        }

        // POST api/<BooksAuthorsController>
        [HttpPost]
        public IActionResult Post(CreateUpdateBookAuthorDTO bookAuthorDTO)
        {
            repo.SaveBookAuthor(mapper.Map<BookAuthor>(bookAuthorDTO));
            return Ok();
        }

        // PUT api/<BooksAuthorsController>/5
        [HttpPut("{bookId}/{authorId}")]
        public IActionResult Put(string bookId, string authorId, CreateUpdateBookAuthorDTO bookAuthorDTO)
        {
            var author = repo.GetBookAuthorById(bookId, authorId);
            if (author is null) return NotFound();
            repo.UpdateBookAuthor(mapper.Map<BookAuthor>(bookAuthorDTO), bookId, authorId);
            return Ok();
        }

        // DELETE api/<BooksAuthorsController>/5
        [HttpDelete("{bookId}/{authorId}")]
        public IActionResult Delete(string bookId, string authorId)
        {
            var author = repo.GetBookAuthorById(bookId, authorId);
            if (author is null) return NotFound();
            repo.DeleteBookAuthor(author);
            return Ok();
        }
    }
}
