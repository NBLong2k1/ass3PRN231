using BusinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IBookRepository
    {
        void SaveBook(Book c);
        Book GetBookById(int id);
        void DeleteBook(Book p);
        void UpdateBook(Book p);
        List<Book> GetBook();
    }
}
