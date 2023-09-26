using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess;
using DataAccess.DAO;
using DataAccess.RepositoryImpl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private IPublisherRepo repo = new PublisherRepo();
        private IMapper mapper;
        public PublishersController(IMapper _mapper) => mapper = _mapper;
        // GET: api/<PublishersController>
        [EnableQuery]
        [HttpGet]
        public ActionResult Get()
            => Ok(repo.GetPublishers().Select(mapper.Map<Publisher, PublisherDTO>).ToList());

        // GET api/<PublishersController>/5
        [EnableQuery]
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var publisher = repo.GetPublisherById(id);
            return publisher is null ? NotFound() : Ok(mapper.Map<PublisherDTO>(publisher));
        }

        // POST api/<PublishersController>
        [EnableQuery]
        [HttpPost]
        public IActionResult Post(PublisherDTO publisherDTO)
        {
            if(repo.GetPublisherById(publisherDTO.PubId) != null)
            {
                return BadRequest("Publisher with ID " + publisherDTO.PubId + " already exists");
            }
            repo.SavePublisher(mapper.Map<Publisher>(publisherDTO));
            return Ok();
        }

        // PUT api/<PublishersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, PublisherDTO publisherDTO)
        {
            var publisherToUpdate = repo.GetPublisherById(id);
            if (publisherToUpdate is null) return NotFound();
            repo.UpdatePublisher(mapper.Map<Publisher>(publisherDTO));
            return Ok();
        }

        // DELETE api/<PublishersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var publisherToDelete = repo.GetPublisherById(id);
            if (publisherToDelete is null) return NotFound();
            //Todo : Check if publisher has any books
            repo.DeletePublisher(publisherToDelete);
            return Ok();
        }
    }
}
