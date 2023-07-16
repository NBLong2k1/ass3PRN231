using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Model.Entities;
using AutoMapper;
using DataAccess.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.OData.Query;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        
        private IPublisherRepository repository = new PublisherRepository();
        private readonly IMapper _mapper;
        public PublishersController(IMapper mapper)
        {
            _mapper = mapper;
            
        }

        // GET: api/Publishers
        [EnableQuery]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publisher>>> GetPublishers()
      => repository.GetPublisher();

        // GET: api/Publishers/5
        [EnableQuery]
        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> GetPublisher(int id)
         => repository.GetPublisherById(id);

        [EnableQuery]
        // PUT: api/Publishers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublisher(int id,[FromBody] PublisherDTO publisher)
        {
            var product = _mapper.Map<Publisher>(publisher);

            var pTmp = repository.GetPublisherById(id);
            if (pTmp == null)

                return NotFound();
            pTmp = product;
            pTmp.PubId = id;
            repository.UpdatePublisher(pTmp);
            return NoContent();

        }

        // POST: api/Publishers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableQuery]
        [HttpPost]
        public async Task<ActionResult<Publisher>> PostPublisher([FromBody]PublisherDTO publisher)
        {

            var aut = _mapper.Map<Publisher>(publisher);


            repository.SavePublisher(aut);

            return NoContent();
        }

        // DELETE: api/Publishers/5
        [EnableQuery]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            if (repository.GetPublisher() == null)
            {
                return NotFound();
            }
            var author = repository.GetPublisherById(id);
            if (author == null)
            {
                return NotFound();
            }

            repository.DeletePublisher(author);

            return NoContent();
        }

      
    }
}
