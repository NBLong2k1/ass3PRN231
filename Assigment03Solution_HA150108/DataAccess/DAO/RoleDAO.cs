using BusinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class RoleDAO
    {
        public static List<Role > GetRole()
        {
            var listRole = new List<Role >();

            try
            {

                using (var context = new eBookStoreContext())
                {
                  
                    listRole = context.Roles.ToList();

                   
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listRole;

        }
        public static Role  FindRoleById(int RoleId)
        {
            Role  p = new Role ();
            try
            {
                using (var context = new eBookStoreContext())
                {
                    p = context.Roles.SingleOrDefault(x => x.RoleId == RoleId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return p;
        }
        public static void SaveRole(Role  p)
        {
            try
            {
                using (var context = new eBookStoreContext())
                {
                    context.Roles.Add(p);
                    context.SaveChanges();
                }

                Console.WriteLine("check");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void UpdateRole(Role  p)
        {
            try
            {
                using (var context = new eBookStoreContext())
                {
                    context.Roles.Update(p);
                    // context.Entry<Products>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public static void DeleteRole(Role  p)
        {
            try
            {
                using (var context = new eBookStoreContext())
                {
                    var p1 = context.Roles.SingleOrDefault(x => x.RoleId == p.RoleId);
                    context.Roles.Remove(p1);
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
