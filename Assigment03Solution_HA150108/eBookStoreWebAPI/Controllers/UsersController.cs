using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Model.Entities;
using Microsoft.AspNetCore.OData.Query;
using AutoMapper;
using DataAccess.IRepository;
using DataAccess.Repository;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository repository = new UserRepository();
        private readonly IMapper _mapper;

        public UsersController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: api/Users
        [EnableQuery]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
              => repository.GetUser();
        // GET: api/Users/5
        [EnableQuery]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
       => repository.GetUserById(id);

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableQuery]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id,[FromBody] UserDTO user)
        {
            var bk = _mapper.Map<User>(user);

            var pTmp = repository.GetUserById(id);
            if (pTmp == null)

                return NotFound();
            pTmp = bk;
            pTmp.UserId = id;
            repository.UpdateUser(pTmp);
            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableQuery]
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDTO user)
        {
            var aut = _mapper.Map<User>(user);

            repository.SaveUser(aut);

            return NoContent();
        }

        // DELETE: api/Users/5
        [EnableQuery]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (repository.GetUser() == null)
            {
                return NotFound();
            }
            var author = repository.GetUserById(id);
            if (author == null)
            {
                return NotFound();
            }

            repository.DeleteUser(author);

            return NoContent();
        }

       
    }
}
