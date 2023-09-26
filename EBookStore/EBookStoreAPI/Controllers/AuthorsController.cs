using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess;
using DataAccess.DAO;
using DataAccess.RepositoryImpl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IAuthorRepo repo = new AuthorRepo();
        private IMapper mapper;
        public AuthorsController(IMapper _mapper) => mapper = _mapper;
        // GET: api/<AuthorsController>
        [EnableQuery]
        [HttpGet]
        public ActionResult Get() => Ok(repo.GetAuthors().Select(mapper.Map<Author, AuthorDTO>).ToList());

        // GET api/<AuthorsController>/5
        [EnableQuery]
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var author = repo.GetAuthorById(id);
            return author is null ? NotFound() : Ok(mapper.Map<AuthorDTO>(author));
        }

        // POST api/<AuthorsController>
        [EnableQuery]
        [HttpPost]
        public IActionResult Post(AuthorDTO authorDTO)
        {
            var authorId = repo.SaveAuthor(mapper.Map<Author>(authorDTO));
            return Ok(authorId);
        }

        // PUT api/<AuthorsController>/5
        [EnableQuery]
        [HttpPut("{id}")]
        public IActionResult Put(string id, AuthorDTO authorDTO)
        {
            var authorToUpdate = repo.GetAuthorById(id);
            if (authorToUpdate is null) return NotFound();
            repo.UpdateAuthor(mapper.Map<Author>(authorDTO));
            return Ok();
        }

        // DELETE api/<AuthorsController>/5
        [EnableQuery]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var authorToDelete = repo.GetAuthorById(id);
            if (authorToDelete is null) return NotFound();
            repo.DeleteAuthor(authorToDelete);
            return Ok();
        }
    }
}
