using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess;
using DataAccess.RepositoryImpl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.OData.ModelBuilder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepo repo = new UserRepo();
        private IMapper mapper;
        public UsersController(IMapper _mapper) => mapper = _mapper;

        // GET: api/<UsersController>
        [EnableQuery]
        [HttpGet]
        public ActionResult GetMembers()
            => Ok(repo.GetUsers().Select(mapper.Map<User, UserDTO>).ToList());

        [EnableQuery]
        // GET api/<UsersController>/5
        [HttpGet]
        [Route("Update/{id}")]
        public ActionResult GetToUpdate(string id)
        {
            var user = repo.GetUserById(id);
            return user is null ? NotFound() : Ok(mapper.Map<CreateUpdateUserDTO>(user));
        }

        [EnableQuery]
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var user = repo.GetUserById(id);
            return user is null ? NotFound() : Ok(mapper.Map<UserDTO>(user));
        }

        // POST api/<UsersController>
        [EnableQuery]
        [HttpPost]
        [Route("Save")]
        public IActionResult Post(CreateUpdateUserDTO userDTO)
        {
            repo.SaveUser(mapper.Map<User>(userDTO));
            return Ok();
        }

        // POST api/<UsersController>/Authen
        [EnableQuery]
        [HttpPost]
        [Route("Authen")]
        public IActionResult Post(AuthenDTO authen)
        {
            var user = repo.GetMemberByEmailAndPassword(authen.EmailAddress, authen.Password);
            return user is null ? NotFound() : Ok(mapper.Map<UserDTO>(user));
        }

        // PUT api/<UsersController>/5
        [EnableQuery]
        [HttpPut("{id}")]
        public IActionResult Put(string id, CreateUpdateUserDTO userDTO)
        {
            var userToUpdate = repo.GetUserById(id);
            if (userToUpdate is null) return NotFound();
            repo.UpdateUser(mapper.Map<User>(userDTO));
            return Ok();
        }

        // DELETE api/<UsersController>/5
        [EnableQuery]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var userToDelete = repo.GetUserById(id);
            if (userToDelete is null) return NotFound();
            repo.DeleteUser(userToDelete);
            return Ok();
        }
    }
}
