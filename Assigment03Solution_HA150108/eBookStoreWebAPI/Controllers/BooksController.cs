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
    public class BooksController : ControllerBase
    {
        private IBookRepository repository = new BookRepository();
        private readonly IMapper _mapper;
        public BooksController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: api/Books
        [EnableQuery]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
       => repository.GetBook();

        // GET: api/Books/5
        [EnableQuery]
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        =>repository.GetBookById(id);

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableQuery]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, [FromBody] BookDTO book)
        {
            var bk = _mapper.Map<Book>(book);

            var pTmp = repository.GetBookById(id);
            if (pTmp == null)

                return NotFound();
            pTmp = bk;
            pTmp.BookId = id;
            repository.UpdateBook(pTmp);
            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromBody]BookDTO book)
        {
            var aut = _mapper.Map<Book>(book);

            repository.SaveBook(aut);

            return NoContent();
        }

        // DELETE: api/Books/5
        [EnableQuery]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (repository.GetBook() == null)
            {
                return NotFound();
            }
            var author = repository.GetBookById(id);
            if (author == null)
            {
                return NotFound();
            }

            repository.DeleteBook(author);

            return NoContent();
        }

       
    }
}
