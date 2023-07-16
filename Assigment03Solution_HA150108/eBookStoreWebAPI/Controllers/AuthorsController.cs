using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Model.Entities;
using DataAccess.IRepository;
using DataAccess.Repository;
using AutoMapper;
using System.Configuration;
using Microsoft.AspNetCore.OData.Query;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IAuthorRepository repository = new AuthorRepository();
        private readonly IMapper _mapper;
        public AuthorsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: api/Authors
        [EnableQuery]
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        => repository.GetAuthor();

        // GET: api/Authors/5
        [EnableQuery]
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
         => repository.GetAuthorById(id);

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableQuery]
        [HttpPut("{id}")]
        public IActionResult PutAuthor(int id, [FromBody] AuthorDTO author)
        {
             
            var product = _mapper.Map<Author>(author);

            var pTmp = repository.GetAuthorById(id);
            if (pTmp == null)

                return NotFound();
            pTmp = product;
            pTmp.AuthorId = id;
            repository.UpdateAuthor(pTmp);
            return NoContent();

        }

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableQuery]
        [HttpPost]
        public IActionResult PostAuthor([FromBody] AuthorDTO author)
        {
            
            var aut=_mapper.Map<Author>(author);


            repository.SaveAuthor(aut);

            return NoContent();
        }

        // DELETE: api/Authors/5
        [EnableQuery]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            if (repository.GetAuthor() == null)
            {
                return NotFound();
            }
            var author = repository.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            repository.DeleteAuthor(author);

            return Ok();
        }

      
    }
}
