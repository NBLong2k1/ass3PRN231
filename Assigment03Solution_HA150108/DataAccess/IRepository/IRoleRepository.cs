using BusinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IRoleRepository
    {
        void SaveRole(Role  c);
        Role  GetRoleById(int id);
        void DeleteRole(Role  p);
        void UpdateRole(Role  p);
        List<Role > GetRole();
    }
}
