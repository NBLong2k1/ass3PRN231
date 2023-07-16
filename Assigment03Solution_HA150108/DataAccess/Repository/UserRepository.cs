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
    public class UserRepository : IUserRepository
    {
        public void DeleteUser(User  p) => UserDAO.DeleteUser(p);

        public List<User > GetUser() => UserDAO.GetUser();

        public User  GetUserById(int id) => UserDAO.FindUserById(id);

        public void SaveUser(User  c) => UserDAO.SaveUser(c);

        public void UpdateUser(User  p) => UserDAO.UpdateUser(p);
    }
}
