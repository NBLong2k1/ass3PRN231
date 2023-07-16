using BusinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class BookDAO
    {
        public static List<Book > GetBook()
        {
            var listBook = new List<Book >();

            try
            {

                using (var context = new eBookStoreContext())
                {
                  
                    listBook = context.Books.ToList();

                
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listBook;

        }
        public static Book  FindBookById(int BookId)
        {
            Book  p = new Book ();
            try
            {
                using (var context = new eBookStoreContext())
                {
                    p = context.Books.SingleOrDefault(x => x.BookId == BookId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return p;
        }
        public static void SaveBook(Book  p)
        {
            try
            {
                using (var context = new eBookStoreContext())
                {
                    context.Books.Add(p);
                    context.SaveChanges();
                }

                Console.WriteLine("check");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void UpdateBook(Book  p)
        {
            try
            {
                using (var context = new eBookStoreContext())
                {
                    context.Books.Update(p);
                    // context.Entry<Products>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public static void DeleteBook(Book  p)
        {
            try
            {
                using (var context = new eBookStoreContext())
                {
                    var p1 = context.Books.SingleOrDefault(x => x.BookId == p.BookId);
                    context.Books.Remove(p1);
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
