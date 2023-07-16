using BusinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class UserDAO
    {
        public static List<User> GetUser()
        {
            var listUser = new List<User>();

            try
            {

                using (var context = new eBookStoreContext())
                {
                   
                    listUser = context.Users.ToList();
 
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listUser;

        }
        public static User FindUserById(int UserId)
        {
            User p = new User();
            try
            {
                using (var context = new eBookStoreContext())
                {
                    p = context.Users.SingleOrDefault(x => x.UserId == UserId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return p;
        }
        public static void SaveUser(User p)
        {
            try
            {
                using (var context = new eBookStoreContext())
                {
                    context.Users.Add(p);
                    context.SaveChanges();
                }

                Console.WriteLine("check");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void UpdateUser(User p)
        {
            try
            {
                using (var context = new eBookStoreContext())
                {
                    context.Users.Update(p);
                    // context.Entry<Products>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public static void DeleteUser(User p)
        {
            try
            {
                using (var context = new eBookStoreContext())
                {
                    var p1 = context.Users.SingleOrDefault(x => x.UserId == p.UserId);
                    context.Users.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
