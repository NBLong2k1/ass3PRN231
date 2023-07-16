using BusinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IBookAuthorRepository
    {
        void SaveBookAuthor(BookAuthor  c);
        BookAuthor  GetBookAuthorById(int id);
        void DeleteBookAuthor(BookAuthor  p);
        void UpdateBookAuthor(BookAuthor  p);
        List<BookAuthor > GetBookAuthor();
    }
}
