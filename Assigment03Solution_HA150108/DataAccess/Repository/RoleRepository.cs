using BusinessObject.Model.Entities;
using DataAccess.DAO;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RoleRepository : IRoleRepository
    {
        public void DeleteRole(Role  p) => RoleDAO.DeleteRole(p);

        public List<Role > GetRole() => RoleDAO.GetRole();

        public Role  GetRoleById(int id) => RoleDAO.FindRoleById(id);

        public void SaveRole(Role  c) => RoleDAO.SaveRole(c);

        public void UpdateRole(Role  p) => RoleDAO.UpdateRole(p);
    }
}
