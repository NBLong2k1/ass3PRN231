using BusinessObject.Model.Entities;
using DataAccess.DAO;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        public void DeleteAuthor(Author  p) => AuthorDAO.DeleteAuthor(p);

        public List<Author > GetAuthor() => AuthorDAO.GetAuthor();

        public Author  GetAuthorById(int id) => AuthorDAO.FindAuthorById(id);

        public void SaveAuthor(Author  c) => AuthorDAO.SaveAuthor(c);

        public void UpdateAuthor(Author  p) => AuthorDAO.UpdateAuthor(p);
    }
}
