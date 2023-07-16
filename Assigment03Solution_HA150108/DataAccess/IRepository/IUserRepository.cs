using BusinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IUserRepository
    {
        void SaveUser(User  c);
        User  GetUserById(int id);
        void DeleteUser(User  p);
        void UpdateUser(User  p);
        List<User > GetUser();
    }
}
