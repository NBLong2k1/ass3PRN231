using BusinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class AuthorDAO
    {
        public static List<Author > GetAuthor()
        {
           
            var listAuthor = new List<Author >();

            try
            {

                using (var context = new eBookStoreContext())
                {
                   
                   
                    listAuthor = context.Authors.ToList();

                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listAuthor;

        }
        public static Author  FindAuthorById(int AuthorId)
        {
            Author  p = new Author ();
            try
            {
                using (var context = new eBookStoreContext())
                {
                    p = context.Authors.SingleOrDefault(x => x.AuthorId == AuthorId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return p;
        }
        public static void SaveAuthor(Author  p)
        {
            try
            {
                using (var context = new eBookStoreContext())
                {
                    context.Authors.Add(p);
                    context.SaveChanges();
                }

                Console.WriteLine("check");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void UpdateAuthor(Author  p)
        {
            try
            {
                using (var context = new eBookStoreContext())
                {
                    context.Authors.Update(p);
                    // context.Entry<Products>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public static void DeleteAuthor(Author  p)
        {
            try
            {
                using (var context = new eBookStoreContext())
                {
                    var p1 = context.Authors.SingleOrDefault(x => x.AuthorId == p.AuthorId);
                    context.Authors.Remove(p1);
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
