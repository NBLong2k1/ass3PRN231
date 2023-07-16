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
    public class RolesController : ControllerBase
    {
        private IRoleRepository repository = new RoleRepository();
        private readonly IMapper _mapper;

        public RolesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: api/Roles
        [EnableQuery]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
      => repository.GetRole();

        // GET: api/Roles/5
        [EnableQuery]
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
     => repository.GetRoleById(id);

        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableQuery]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, [FromBody]RoleDTO role)
        {
            var bk = _mapper.Map<Role>(role);

            var pTmp = repository.GetRoleById(id);
            if (pTmp == null)

                return NotFound();
            pTmp = bk;
            pTmp.RoleId = id;
            repository.UpdateRole(pTmp);
            return NoContent();
        }

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableQuery]
        [HttpPost]
        public async Task<ActionResult<Role>> PostRole([FromBody]RoleDTO role)
        {
            var aut = _mapper.Map<Role>(role);

            repository.SaveRole(aut);

            return NoContent();
        }

        // DELETE: api/Roles/5
        [EnableQuery]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {

            if (repository.GetRole() == null)
            {
                return NotFound();
            }
            var author = repository.GetRoleById(id);
            if (author == null)
            {
                return NotFound();
            }

            repository.DeleteRole(author);

            return NoContent();
        }

        
    }
}
