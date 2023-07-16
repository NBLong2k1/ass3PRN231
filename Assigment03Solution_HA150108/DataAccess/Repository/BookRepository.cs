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
    public class BookRepository : IBookRepository
    {
        public void DeleteBook(Book  p) => BookDAO.DeleteBook(p);

        public List<Book > GetBook() => BookDAO.GetBook();

        public Book  GetBookById(int id) => BookDAO.FindBookById(id);

        public void SaveBook(Book  c) => BookDAO.SaveBook(c);

        public void UpdateBook(Book  p) => BookDAO.UpdateBook(p);
    }
}
