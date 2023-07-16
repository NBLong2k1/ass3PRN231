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
    public class BookAuthorRepository : IBookAuthorRepository
    {
        public void DeleteBookAuthor(BookAuthor  p) => BookAuthorDAO.DeleteBookAuthor(p);

        public List<BookAuthor > GetBookAuthor() => BookAuthorDAO.GetBookAuthor();

        public BookAuthor  GetBookAuthorById(int id) => BookAuthorDAO.FindBookAuthorById(id);

        public void SaveBookAuthor(BookAuthor  c) => BookAuthorDAO.SaveBookAuthor(c);

        public void UpdateBookAuthor(BookAuthor  p) => BookAuthorDAO.UpdateBookAuthor(p);
    }
}
