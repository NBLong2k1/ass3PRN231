using BusinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class BookAuthorDAO
    {
        public static List<BookAuthor > GetBookAuthor()
        {
            var listBookAuthor = new List<BookAuthor >();

            try
            {

                using (var context = new eBookStoreContext())
                {
                  
                    listBookAuthor = context.BookAuthors.ToList();

                   
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listBookAuthor;

        }
        public static BookAuthor  FindBookAuthorById(int BookAuthorId)
        {
            BookAuthor  p = new BookAuthor ();
            try
            {
                using (var context = new eBookStoreContext())
                {
                    p = context.BookAuthors.SingleOrDefault(x => x.AuthorId == BookAuthorId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return p;
        }
        public static void SaveBookAuthor(BookAuthor  p)
        {
            try
            {
                using (var context = new eBookStoreContext())
                {
                    context.BookAuthors.Add(p);
                    context.SaveChanges();
                }

                Console.WriteLine("check");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void UpdateBookAuthor(BookAuthor  p)
        {
            try
            {
                using (var context = new eBookStoreContext())
                {
                    context.BookAuthors.Update(p);
                    // context.Entry<Products>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public static void DeleteBookAuthor(BookAuthor  p)
        {
            try
            {
                using (var context = new eBookStoreContext())
                {
                    var p1 = context.BookAuthors.SingleOrDefault(x => x.AuthorId == p.AuthorId);
                    context.BookAuthors.Remove(p1);
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
