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
    public class BookAuthorsController : ControllerBase
    {
        private IBookAuthorRepository repository = new BookAuthorRepository();
        private readonly IMapper _mapper;

        public BookAuthorsController(IMapper mapper)
        {
            _mapper=mapper;
        }

        // GET: api/BookAuthors
        [EnableQuery]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookAuthor>>> GetBookAuthors()
         => repository.GetBookAuthor();
        // GET: api/BookAuthors/5
        [EnableQuery]
        [HttpGet("{id}")]
        public async Task<ActionResult<BookAuthor>> GetBookAuthor(int id)
        => repository.GetBookAuthorById(id);

        // PUT: api/BookAuthors/5

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableQuery]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookAuthor(int id, [FromBody] BookAuthorDTO bookAuthor)
        {
            var product = _mapper.Map<BookAuthor>(bookAuthor);

            var pTmp = repository.GetBookAuthorById(id);
            if (pTmp == null)

                return NotFound();
            pTmp = product;
            pTmp.AuthorId = id;
            repository.UpdateBookAuthor(pTmp);
            return NoContent();
        }

        // POST: api/BookAuthors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableQuery]
        [HttpPost]
        public IActionResult PostBookAuthor([FromBody] BookAuthorDTO bookAuthor)
        {
            var aut = _mapper.Map<BookAuthor>(bookAuthor);


            repository.SaveBookAuthor(aut);

            return NoContent();

        }

        // DELETE: api/BookAuthors/5
        [EnableQuery]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookAuthor(int id)
        {
            if (repository.GetBookAuthor() == null)
            {
                return NotFound();
            }
            var author = repository.GetBookAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            repository.DeleteBookAuthor(author);

            return NoContent();
        }

       
    }
}
